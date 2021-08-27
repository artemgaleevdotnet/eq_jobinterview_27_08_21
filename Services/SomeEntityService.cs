using Interview.DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Services
{
    internal class SomeEntityService : ISomeEntityService
    {
        private readonly ISomeEntityRepository _someEntityRepository;

        public SomeEntityService(ISomeEntityRepository someEntityRepository)
        {
            _someEntityRepository = someEntityRepository;
        }

        public Task<ISomeEntity> Create(ISomeEntity value)
        {
            // some logic, if required

            return _someEntityRepository.Create(value);
        }

        public Task<ISomeEntity> Delete(Guid id)
        {
            // some logic, if required

            return _someEntityRepository.Delete(id);
        }

        public Task<IEnumerable<ISomeEntity>> GetAll()
        {
            // some logic, if required

            return _someEntityRepository.ReadAll();
        }

        public Task<ISomeEntity> GetById(Guid id)
        {
            // some logic, if required

            return _someEntityRepository.ReadById(id);
        }

        public Task<ISomeEntity> Update(Guid id, ISomeEntity value)
        {
            var entity = new SomeEntity(value);

            entity.Id = id;

            return _someEntityRepository.Update(entity);
        }
    }
}
