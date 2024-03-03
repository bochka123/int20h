using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Question;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services
{
    public class QuestionService: BaseService, IQuestionService
    {
        public QuestionService(ApplicationDbContext applicationDbContext, IMapper mapper): base(applicationDbContext, mapper)
        {

        }

        public async Task<Response<IEnumerable<QuestionResponseDto>>> GetByTaskId(Guid testId)
        {
            var test = _context.Tests.Include(x => x.Questions).FirstOrDefault(x => x.Id == testId);
            if (test == null)
            {
                return new Response<IEnumerable<QuestionResponseDto>>(Status.Error, "Test not found.");
            }
            var questions = test.Questions.ToList();

            return new Response<IEnumerable<QuestionResponseDto>>(_mapper.Map<IEnumerable<Question>, IEnumerable<QuestionResponseDto>>(questions));
        }

        public async Task<Response<IEnumerable<QuestionResponseDto>>> CreateMany(IEnumerable<QuestionDto> questionsDtos, Guid testId)
        {
            var test = _context.Tests.FirstOrDefault(x => x.Id == testId);
            if (test == null)
            {
                return new Response<IEnumerable<QuestionResponseDto>>(Status.Error, "Test not found.");
            }
            var questions = new List<QuestionResponseDto>();
            
            foreach (var questionDto in questionsDtos)
            {
                var question = _mapper.Map<Question>(questionDto);
                question.Id = Guid.NewGuid();
                question.TestId = test.Id;
                foreach (var optionDto in questionDto.QuestionOptions)
                {
                    var option = new QuestionOption()
                    {
                        Text = optionDto.Text,
                        QuestionId = question.Id,
                        IsCorrect = optionDto.IsCorrect
                    };
                    question.QuestionOptions.Add(option);
                }
                questions.Add(_mapper.Map<QuestionResponseDto>(question));
                _context.Questions.Add(question);
            }
            await _context.SaveChangesAsync();

            return new Response<IEnumerable<QuestionResponseDto>>();
        }

        public async Task<Response<QuestionResponseDto>> Create(QuestionDto questionDto, Guid testId)
        {
            var test = _context.Tests.FirstOrDefault(x => x.Id == testId);
            if (test == null)
            {
                return new Response<QuestionResponseDto>(Status.Error, "Test not found.");
            }

            var question = _mapper.Map<Question>(questionDto);
            question.Id = Guid.NewGuid();
            question.TestId = test.Id;
            foreach (var optionDto in questionDto.QuestionOptions)
            {
                var option = new QuestionOption()
                {
                    Text = optionDto.Text,
                    QuestionId = question.Id,
                    IsCorrect = optionDto.IsCorrect
                };
                question.QuestionOptions.Add(option);
            }
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();


            return new Response<QuestionResponseDto>(_mapper.Map<QuestionResponseDto>(question), "Question created successfully");
        }

        public async Task<Response<QuestionResponseDto>> Edit(QuestionDto questionDto, Guid questionId)
        {
            var question = _context.Questions.Include(x => x.QuestionOptions).FirstOrDefault(x => x.Id == questionId);
            if (question == null)
            {
                return new Response<QuestionResponseDto>(Status.Error, "Question not found.");
            }

            _mapper.Map(questionDto, question);

            question.UpdatedAt = DateTime.UtcNow;

            foreach (var optionDto in questionDto.QuestionOptions)
            {
                var existingOption = question.QuestionOptions.FirstOrDefault(o => o.Text == optionDto.Text);

                if (existingOption == null)
                {
                    var newOption = new QuestionOption()
                    {
                        Text = optionDto.Text,
                        IsCorrect = optionDto.IsCorrect,
                        QuestionId = question.Id
                    };
                    question.QuestionOptions.Add(newOption);
                }
            }
            var notExistingOptions = question.QuestionOptions.Where(o => !questionDto.QuestionOptions.Any(x => x.Text == o.Text));
            foreach (var optionDto in notExistingOptions) 
            {
                _context.QuestionOptions.Remove(optionDto);
            }

            await _context.SaveChangesAsync();

            return new Response<QuestionResponseDto>(_mapper.Map<QuestionResponseDto>(question), "Question updated successfully");
        }

        public async Task<Response<QuestionResponseDto>> Delete(Guid questionId)
        {
            var question = _context.Questions.Include(x => x.QuestionOptions).FirstOrDefault(x => x.Id == questionId);
            if (question == null)
            {
                return new Response<QuestionResponseDto>(Status.Error, "Question not found.");
            }

            foreach (var option in question.QuestionOptions)
            {
                _context.QuestionOptions.Remove(option);
            }

            _context.Questions.Remove(question);

            await _context.SaveChangesAsync();    

            return new Response<QuestionResponseDto>(Status.Success, "Question and associated answers deleted successfully");
        }
    }
}
