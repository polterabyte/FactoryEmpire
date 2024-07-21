using Services;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope// MonoBehaviour, IProjectContext
{
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterServices(builder);
        
        builder.RegisterEntryPoint<GameEntryPoint>();
    }

    private void RegisterServices(IContainerBuilder builder)
    {
        builder.Register<UserAuthorizationService>(Lifetime.Singleton);
        builder.Register<SceneLoaderService>(Lifetime.Singleton);

    }
}