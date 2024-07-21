using Services;

namespace Scenes.MainScene.UI
{
    public class FactoryScreenService
    {
        private readonly UIService _uiService;

        public FactoryScreenService(UIService uiService)
        {
            _uiService = uiService;
        }
        
        public void SwitchToMainMenuScreen()
        {
            _uiService.ShowScreen<MainScreenPresenter>();
        }
    }
}