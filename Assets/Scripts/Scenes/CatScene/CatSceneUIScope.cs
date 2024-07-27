using Scenes.CatScene.UI;
using Services;
using VContainer;
using VContainer.Unity;

namespace Scenes.CatScene
{
    public class CatSceneUIScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UIService>(Lifetime.Singleton);
            
            builder.RegisterComponentInHierarchy<SplashScreenScript>();
            builder.Register<SplashScreenService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<SplashScreenPresenter>();
            
            builder.RegisterBuildCallback(resolver => resolver.Resolve<UIService>().Initialize());
        }
    }
}