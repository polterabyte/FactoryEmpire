using System.Collections.Generic;
using Common;
using Cysharp.Threading.Tasks;

namespace GameEntities.Repos
{
    public class RecipeRepository: IRepository<RecipeData>
    {
        public IEnumerable<RecipeData> All { get; private set; }

        private readonly IRepositoryReader<RecipeData> _reader;
        
        public RecipeRepository(IRepositoryReader<RecipeData> reader)
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