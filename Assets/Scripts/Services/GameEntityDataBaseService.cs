using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Cysharp.Threading.Tasks;
using GameEntities;
using GameEntities.Repos;
using UnityEngine;

namespace Services
{
    public class GameEntityDataBaseService : ISaveLoaderService
    {
        public IEnumerable<RecipeData> Recipes { get; private set; }
        public IEnumerable<BuildingData> Buildings { get; private set; }
        
        private readonly RecipeRepository _recipeRepository;
        private readonly BuildingRepository _buildingRepository;
        


        public GameEntityDataBaseService(
            IRepositoryReader<RecipeData> recipeReader,
            IRepositoryReader<BuildingData> buildingReader)
        {
            _buildingRepository = new BuildingRepository(buildingReader);
            _recipeRepository = new RecipeRepository(recipeReader);

            Recipes = new List<RecipeData>();
        }

        public async UniTask<bool> Update()
        {
            var loadResult = await UniTask.WhenAll(new[] { _recipeRepository.Read(), _buildingRepository.Read() });

            if (!loadResult.All(x => x)) return false;
            
            
            Recipes = _recipeRepository.All;
            Buildings = _buildingRepository.All;
            
            return true;

        }

        public IEnumerable<RecipeData> GetRecipeDataFor(string itemNameId)
        {
            return Recipes.Where(x => x.outItem.nameId.Equals(itemNameId));
            
        }

        public UniTask<bool> Save()
        {
            return UniTask.FromResult(true);
        }
    }


}