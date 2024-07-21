using Services;
using VContainer;
using VContainer.Unity;

namespace Scenes.MainScene
{
    public class MainSceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ClickService>(Lifetime.Singleton);
        }
    }
}