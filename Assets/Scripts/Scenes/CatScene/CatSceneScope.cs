using Services;
using VContainer;
using VContainer.Unity;

namespace Scenes.CatScene
{
    public class CatSceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CatSceneEntryPoint>();

            builder.RegisterInstance(new CatSceneModel());
        }
    }
}