using Common;
using Scenes.MainScene.UI;
using Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scenes.MainScene
{
    public class MainSceneUIScope : LifetimeScope
    {

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UIService>(Lifetime.Singleton);
            
            builder.RegisterComponentInHierarchy<MainScreenScript>();
            builder.Register<MainScreenService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MainScreenPresenter>();

            builder.RegisterComponentInHierarchy<FactoryScreenScript>();
            builder.Register<FactoryScreenService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<FactoryScreenPresenter>();
            
            builder.RegisterBuildCallback(resolver => resolver.Resolve<UIService>().Initialize());
        }
    }
}