using Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Services;
using VContainer.Unity;

namespace Scenes.MainScene.UI
{
    public class FactoryScreenPresenter : ScreenPresenterBase<FactoryScreenScript>,  IStartable
    {
        private readonly FactoryScreenService _service;
        private readonly ClickService _clickService;


        public FactoryScreenPresenter(FactoryScreenScript view, FactoryScreenService service, ClickService clickService) : base(view)
        {
            _service = service;
            _clickService = clickService;
        }
        
        public void Start()
        {
            var destroyToken = View.gameObject.GetCancellationTokenOnDestroy();
            
            View.btToMainMenu
                .OnClickAsAsyncEnumerable()
                .Subscribe(_ => _service.SwitchToMainMenuScreen())
                .AddTo(destroyToken)
                ;

            View.btClick
                .OnClickAsAsyncEnumerable()
                .Subscribe(_ => _clickService.ApplyClick())
                .AddTo(destroyToken)
                ;
        }
    }
}