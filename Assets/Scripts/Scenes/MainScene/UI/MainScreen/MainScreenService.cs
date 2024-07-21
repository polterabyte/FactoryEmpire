using Services;
using UnityEngine;

namespace Scenes.MainScene.UI
{
    public class MainScreenService
    {
        private readonly UIService _uiService;

        public MainScreenService(UIService uiService)
        {
            _uiService = uiService;
        }
        
        public void SwitchToFactoryScreen()
        {
            _uiService.ShowScreen<FactoryScreenPresenter>();
        }
    }
}