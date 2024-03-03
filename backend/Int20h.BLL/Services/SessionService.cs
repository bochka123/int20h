using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Question;
using Int20h.Common.Dtos.Session;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services
{
    public class SessionService: BaseService, ISessionService
    {
        private readonly ICredentialService _credentialService;
        public SessionService(ApplicationDbContext applicationDbContext, IMapper mapper, ICredentialService credentialService): base(applicationDbContext, mapper) 
        {
            _credentialService = credentialService;
        }

        public Common.Response.Response<SessionDto> CreateSession(Guid SessionId)
        {
            var userId = _credentialService.UserId;
            var student = _context.StudentInformations.FirstOrDefault(x => x.UserId == userId);
            if ( student == null)
            {
                return new Common.Response.Response<SessionDto>(Status.Error, "You cannot start the session.");
            }
            var session = new TestSession()
            {
                StudentId = student.Id,
                TestId = SessionId,
            };
            _context.TestSessions.Add(session);
            _context.SaveChanges();
            return new Common.Response.Response<SessionDto>(_mapper.Map<SessionDto>(session));
        }
        public Common.Response.Response<QuestionResponseDto> Get(Guid SessionId)
        {
            var userId = _credentialService.UserId;
            var session = _context.TestSessions.Include(x => x.Test).ThenInclude(x => x.Questions).ThenInclude(x => x.QuestionOptions).Include(x => x.Answers).FirstOrDefault(x => x.Id == SessionId);
            if (session == null)
            {
                return new Common.Response.Response<QuestionResponseDto>(Status.Error, "Session is not found.");
            }
            var question = session.Test.Questions.FirstOrDefault(x => x.QuestionOptions.Any(i => !session.Answers.Any(j => j.AnswerId == i.Id)));
            if (question != null)
            {
                return new Response<QuestionResponseDto>(_mapper.Map<QuestionResponseDto>(question));
            }
            return new Response<QuestionResponseDto>(Status.Success, "Session is over.");

        }
        public Common.Response.Response AddSessionAnswer(CreateSessionAnswer sessionAnswer)
        {
            var session = _context.TestSessions.Include(x => x.Test).ThenInclude(x => x.Questions).Include(x => x.Answers).FirstOrDefault(x => x.Id == sessionAnswer.SessionId);
            if (session == null)
            {
                return new Common.Response.Response(Status.Error, "Sesssion is not found.");
            }
            var option = _context.QuestionOptions.Include(x => x.Question).FirstOrDefault(x => x.Id == sessionAnswer.ChoosedOption);
            if (option == null)
            {
                return new Common.Response.Response(Status.Error, "Option is not found.");
            }
            var question = option.Question;

            var newAnswer = new SessionAnswer()
            {
                AnswerId = option.Id,
                SessionId = session.Id,
                IsCorrect = option.IsCorrect
            };

            _context.SessionAnswers.Add(newAnswer);
            if (session.Test.Questions.Count() == session.Answers.Count())
            {
                session.Mark = session.Answers.Count(x => x.IsCorrect)/session.Test.Questions.Count() * session.Test.Cost;
            }
            _context.SaveChanges();

            return new Response(Status.Success, "Answer created!");
        }

        public Common.Response.Response<SessionDto> GetSession(Guid SessionId)
        {
            var session = _context.TestSessions.Include(x => x.Answers).ThenInclude(x => x.Answer).FirstOrDefault(x => x.Id == SessionId);
            if (session == null)
            {
                return new Common.Response.Response<SessionDto>(Status.Error, "Sesssion is not found.");
            }
            var sessionDto = _mapper.Map<SessionDto>(session);
            sessionDto.Answers = session!.Answers.Select(c => new SessionAnswerDto() { Answer = c.Answer.Text, IsCorrect = c.IsCorrect });
            _context.SaveChanges();
            return new Common.Response.Response<SessionDto>(_mapper.Map<SessionDto>(session));
        }
    }
}
