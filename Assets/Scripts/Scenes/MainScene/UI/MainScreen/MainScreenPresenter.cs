using Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using VContainer;
using VContainer.Unity;

namespace Scenes.MainScene.UI
{
    public class MainScreenPresenter : ScreenPresenterBase<MainScreenScript>, IStartable
    {
        private readonly MainScreenService _service;


        public MainScreenPresenter(MainScreenScript view, MainScreenService service) : base(view)
        {
            _service = service;
        }

        public void Start()
        {
            View.btToFactory
                .OnClickAsAsyncEnumerable()
                .Subscribe(_ => _service.SwitchToFactoryScreen())
                .AddTo(View.GetCancellationTokenOnDestroy())
                ;
        }
    }
}