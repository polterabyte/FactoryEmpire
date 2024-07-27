using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Cysharp.Threading.Tasks;
using GameEntities.Repos;

namespace GameEntities
{
    public class SORecipeRepositoryReader : IRepositoryReader<RecipeData>
    {
        private readonly SOGameEntityData _db;

        public SORecipeRepositoryReader(SOGameEntityData db)
        {
            _db = db;
        }

        public UniTask<bool> CreateTable()
        {
            return UniTask.FromResult(true);
        }

        public UniTask<IEnumerable<RecipeData>> ReadTable()
        {
            return UniTask.FromResult((IEnumerable<RecipeData>)_db.recipeData);
        }

        public UniTask RemoveTable()
        {
            return UniTask.CompletedTask;
        }

        public UniTask<bool> AddItem(RecipeData item)
        {
            var retVal = false;
            if (!_db.recipeData.Any(x => x.Equals(item)))
            {
                _db.recipeData.Add(item);
                
                retVal = true;
            }
            
            return UniTask.FromResult(retVal);
        }

        public UniTask<bool> RemoveItem(RecipeData item)
        {
            var retVal = false;
            var elems = _db.recipeData.Where(x=> x.Equals(item)).ToArray();
            if (elems.Count() > 1)
                throw new Exception($"Found {elems.Length} items of {item.outItem.nameId} for removing");
            
            if (elems.Count() == 1)
            {
                _db.recipeData.Remove(elems[0]);
                retVal = true;
            }
            
            return UniTask.FromResult(retVal);
        }
    }
}