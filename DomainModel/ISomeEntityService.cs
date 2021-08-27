using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.DomainModel
{

    public interface ISomeEntityService
    {
        Task<IEnumerable<ISomeEntity>> GetAll();
        Task<ISomeEntity> GetById(Guid id);
        Task<ISomeEntity> Create(ISomeEntity value);
        Task<ISomeEntity> Update(Guid id, ISomeEntity value);
        Task<ISomeEntity> Delete(Guid id);
    }
}
