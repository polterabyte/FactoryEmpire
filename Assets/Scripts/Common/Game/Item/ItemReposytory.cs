using System;
using System.Collections.Generic;

namespace Common.Game.Item
{
    public class ItemRepository
    {
        private Dictionary<string, ItemData> _itemMap = new()
        {
            { "", new ItemData() }
        };
    }

    public class RecipeRepository
    {
        private Dictionary<string, RecipeData> _itemMap = new()
        {
            { "", new RecipeData() }
        };
    }


    [Serializable]
    public struct ItemData
    {
        public string id;
        public string recipeId;
    }

    [Serializable]
    public struct ItemInfo
    {
        public ItemData item;
        public int count;
    }
    
    [Serializable]
    public struct RecipeData
    {
        public string id;
        public ItemInfo outItem;
        public List<ItemInfo> inputItems;
    }
}