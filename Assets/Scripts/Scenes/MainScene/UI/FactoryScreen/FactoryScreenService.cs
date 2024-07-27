using Services;
using UnityEngine;

namespace Scenes.MainScene.UI
{
    public class FactoryScreenService
    {
        private readonly UIService _uiService;
        private readonly GameEntityDataBaseService _gameEntityDataBaseService;

        public FactoryScreenService(UIService uiService, GameEntityDataBaseService gameEntityDataBaseService)
        {
            _uiService = uiService;
            _gameEntityDataBaseService = gameEntityDataBaseService;
        }
        
        public void SwitchToMainMenuScreen()
        {
            _uiService.ShowScreen<MainScreenPresenter>();
        }

        public void DebugPrint()
        {
            foreach (var recipe in _gameEntityDataBaseService.Recipes)
            {
                Debug.Log(recipe.outItem.nameId);
            }
        }
    }
}