/*using AutoMapper;
using Karizma.Sample.Contracts.Dtos;
using Karizma.Sample.Domain.Entities.Test;
using Karizma.Sample.Domain.Repositories;
using Karizma.Sample.Services.Abstractions.Test;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.Test
{
    public class TestChildService : ITestChildService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestChildService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork= unitOfWork;

            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            var testChild = await _unitOfWork.GetRepository<TestChild>().Get(t => t.Id == id);

            await _unitOfWork.GetRepository<TestChild>().Delete(t=>t.Id==id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TestChildDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var testChildren = await _unitOfWork.GetRepository<TestChild>().GetAll(cancellationToken);

            var result=_mapper.Map<IEnumerable<TestChildDto>>(testChildren);

            return result;
        }

        public async Task<TestChildDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var testChildDto = await _unitOfWork.GetRepository<TestChild>().GetByCondition(t=>t.Equals(id), cancellationToken);

            var result=_mapper.Map<TestChildDto>(testChildDto);
            
            return result;  
        }

        public async Task InsertAsync(TestChildDto testChildDto, CancellationToken cancellationToken = default)
        {
            var testChild=_mapper.Map<TestChild>(testChildDto);

            await _unitOfWork.GetRepository<TestChild>().Post(testChild,cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
*/