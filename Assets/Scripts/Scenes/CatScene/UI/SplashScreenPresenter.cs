using Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using VContainer.Unity;

namespace Scenes.CatScene.UI
{
    public class SplashScreenPresenter : ScreenPresenterBase<SplashScreenScript>, IStartable
    {
        private readonly SplashScreenService _service;


        public SplashScreenPresenter(SplashScreenScript view, SplashScreenService service) : base(view)
        {
            _service = service;
        }
        public void Start()
        {
            UniTaskAsyncEnumerable
                .EveryValueChanged(_service.data, data => data.InitializationProgress)
                .Subscribe(x => View.progressSlider.value = x)
                .AddTo(View.GetCancellationTokenOnDestroy())
                ;
        }
    }
}