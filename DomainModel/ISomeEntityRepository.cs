using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.DomainModel
{
    public interface ISomeEntityRepository
    {
        Task<ISomeEntity> Create(ISomeEntity someEntity);
        Task<ISomeEntity> Update(ISomeEntity someEntity);
        Task<IEnumerable<ISomeEntity>> ReadAll();
        Task<ISomeEntity> ReadById(Guid id);
        Task<ISomeEntity> Delete(Guid id);
    }
}
