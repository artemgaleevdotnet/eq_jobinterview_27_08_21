using Interview.DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.DataAccess
{
    internal class SomeEntityRepository : ISomeEntityRepository
    {
        private readonly string _filePath;
        private readonly IFileReaderWriter _fileReaderWriter;

        public SomeEntityRepository(IFileReaderWriter fileReaderWriter, ISettings settings)
        {
            _filePath = settings.Path;
            _fileReaderWriter = fileReaderWriter;
        }

        public async Task<ISomeEntity> Create(ISomeEntity someEntity)
        {
            var data = await _fileReaderWriter.Read(_filePath);

            var entitiesArray = JsonConvert.DeserializeObject<IEnumerable<SomeEntity>>(data)?.ToList() ?? new List<SomeEntity>(1);

            var newE = new SomeEntity(someEntity);
            newE.Id = Guid.NewGuid();

            entitiesArray.Add(newE);

            var newData = JsonConvert.SerializeObject(entitiesArray);

            await _fileReaderWriter.Write(_filePath, newData);

            return newE;
        }

        public async Task<ISomeEntity> Delete(Guid id)
        {
            var data = await _fileReaderWriter.Read(_filePath);

            var entitiesArray = JsonConvert.DeserializeObject<IEnumerable<SomeEntity>>(data)?.ToList();

            var entity = entitiesArray?.FirstOrDefault(e => e.Id == id);

            if (entity == default)
            {
                return entity;
            }

            entitiesArray.Remove(entity);

            var newData = JsonConvert.SerializeObject(entitiesArray);

            await _fileReaderWriter.Write(_filePath, newData);

            return entity;
        }

        public async Task<IEnumerable<ISomeEntity>> ReadAll()
        {
            var data = await _fileReaderWriter.Read(_filePath);

            return JsonConvert.DeserializeObject<IEnumerable<SomeEntity>>(data);
        }

        public async Task<ISomeEntity> ReadById(Guid id)
        {
            var data = await _fileReaderWriter.Read(_filePath);

            return JsonConvert.DeserializeObject<IEnumerable<SomeEntity>>(data)?
                .FirstOrDefault(ent => ent.Id == id);
        }

        public async Task<ISomeEntity> Update(ISomeEntity someEntity)
        {
            var data = await _fileReaderWriter.Read(_filePath);

            var entitiesArray = JsonConvert.DeserializeObject<IEnumerable<SomeEntity>>(data)?.ToList();

            var eIndex = entitiesArray?.FindIndex(e => e.Id == someEntity.Id) ?? -1;

            if (eIndex == -1)
            {
                return default;
            }

            var newE = new SomeEntity(someEntity);

            entitiesArray[eIndex] = newE;

            var newData = JsonConvert.SerializeObject(entitiesArray);

            await _fileReaderWriter.Write(_filePath, newData);

            return newE;
        }
    }
}
