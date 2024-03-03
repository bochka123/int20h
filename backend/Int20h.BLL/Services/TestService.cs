using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.Test;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Int20h.BLL.Services
{
    public class TestService: BaseService, ITestService
    {
        private readonly IPagingService _pagingService;
        public TestService(ApplicationDbContext applicationDbContext, IMapper mapper, IPagingService pagingService): base(applicationDbContext, mapper) 
        {
            _pagingService = pagingService;
        }

        public async Task<PageResponse<IEnumerable<TestDto>>> Get(GetRequest request)
        {
            var query = _context.Tests.AsNoTracking().AsQueryable();
            return await _pagingService.ApplyPaging<Test, TestDto>(query, request);
        }

        public async Task<Response<TestDto>> Create(CreateTestDto testDto)
        {
            var testE = _mapper.Map<Test>(testDto);

            _context.Tests.Add(testE);

            var newTest = await _context.SaveChangesAsync();

            return new Response<TestDto>(_mapper.Map<TestDto>(newTest), "Test created successfully");
        }
        public async Task<Response<TestDto>> Edit(TestEditDto testDto)
        {
            var test =_context.Tests.FirstOrDefault(x => x.Id == testDto.Id);

            if (test == null) return new Response<TestDto>(Status.Error, "Test does not found");

            _mapper.Map(testDto, test);

            test.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new Response<TestDto>(_mapper.Map<TestDto>(test), "Test updated successfully");
        }
    }
}
