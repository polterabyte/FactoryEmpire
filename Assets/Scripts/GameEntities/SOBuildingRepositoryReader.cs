using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Cysharp.Threading.Tasks;
using GameEntities.Repos;

namespace GameEntities
{
    public class SOBuildingRepositoryReader : IRepositoryReader<BuildingData>
    {
        private readonly SOGameEntityData _db;

        public SOBuildingRepositoryReader(SOGameEntityData db)
        {
            _db = db;
        }
        
        public UniTask<bool> CreateTable()
        {
            return UniTask.FromResult(true);
        }

        public UniTask<IEnumerable<BuildingData>> ReadTable()
        {
            return UniTask.FromResult((IEnumerable<BuildingData>)_db.buildingData);
        }

        public UniTask RemoveTable()
        {
            return UniTask.CompletedTask;
        }

        public UniTask<bool> AddItem(BuildingData item)
        {
            var retVal = false;
            if (!_db.buildingData.Any(x => x.Equals(item)))
            {
                _db.buildingData.Add(item);
                
                retVal = true;
            }
            
            return UniTask.FromResult(retVal);
        }


        public UniTask<bool> RemoveItem(BuildingData item)
        {
            var retVal = false;
            var elems = _db.buildingData.Where(x=> x.Equals(item)).ToArray();
            if (elems.Count() > 1)
                throw new Exception($"Found {elems.Length} items of {item.nameId} for removing");
            
            if (elems.Count() == 1)
            {
                _db.buildingData.Remove(elems[0]);
                retVal = true;
            }
            
            return UniTask.FromResult(retVal);
        }
    }
}