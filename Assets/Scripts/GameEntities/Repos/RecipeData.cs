using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEntities.Repos
{
    [Serializable]
    public struct RecipeData
    {
        public RecipeDataInfo outItem;
        public List<RecipeDataInfo> inputItems;
        public int craftSpeedInTacks;


        public override bool Equals(object obj)
        {
            if (obj is RecipeData recipeData)
            {
                return Equals(recipeData);
            }


            return false;
        }

        public bool Equals(RecipeData other)
        {
            return outItem.Equals(other.outItem) &&
                   inputItems.All(x => other.inputItems.Any(y => y.nameId.Equals(x.nameId) && y.count.Equals(x.count))) &&
                   craftSpeedInTacks.Equals(other.craftSpeedInTacks);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(outItem, inputItems, craftSpeedInTacks);
        }
    }

    [Serializable]
    public struct RecipeDataInfo
    {
        public string nameId;
        public int count;
    }

    [Serializable]
    public struct ItemDict
    {
        public List<string> itemNameId;
    }
}