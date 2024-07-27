using GameEntities;
using Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope// MonoBehaviour, IProjectContext
{
    [SerializeField]
    private SOGameEntityData localResourcesDataBase;
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterServices(builder);
        
        builder.RegisterEntryPoint<GameEntryPoint>();
    }

    private void RegisterServices(IContainerBuilder builder)
    {
        builder.Register<UserAuthorizationService>(Lifetime.Singleton);
        builder.Register<SceneLoaderService>(Lifetime.Singleton);
        builder.Register<GameEntityDataBaseService>(Lifetime.Singleton)
            .WithParameter("recipeReader", new SORecipeRepositoryReader(localResourcesDataBase))
            .WithParameter("buildingReader", new SOBuildingRepositoryReader(localResourcesDataBase))
            ;
        

    }
}