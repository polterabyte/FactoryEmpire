using System.Collections.Generic;
using Common;
using Cysharp.Threading.Tasks;

namespace GameEntities.Repos
{
    public class BuildingRepository: IRepository<BuildingData>
    {
        public IEnumerable<BuildingData> All { get; private set; }

        private readonly IRepositoryReader<BuildingData> _reader;
        
        public BuildingRepository(IRepositoryReader<BuildingData> reader)
        {
            _reader = reader;
        }

        public async UniTask<bool> Read()
        {
            if (_reader == null) return await UniTask.FromResult(false);

            All = await _reader.ReadTable();

            return await UniTask.FromResult(All != null);
        }
    }
}