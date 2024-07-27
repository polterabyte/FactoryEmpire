using System.Collections.Generic;
using GameEntities.Repos;
using UnityEngine;

namespace GameEntities
{
    [CreateAssetMenu]
    public class SOGameEntityData : ScriptableObject
    {
        public List<string> recipeDict;
        public List<string> buildingDict;
        public List<RecipeData> recipeData;
        public List<BuildingData> buildingData;
    }
}