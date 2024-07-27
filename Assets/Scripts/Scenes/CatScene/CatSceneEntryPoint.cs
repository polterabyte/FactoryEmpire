using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scenes.CatScene
{
    public class CatSceneEntryPoint : IAsyncStartable
    {
        [Inject]
        private UserAuthorizationService _userAuthorizationService;

        [Inject] 
        private GameEntityDataBaseService _gameEntityDataBaseService;

        [Inject]
        private SceneLoaderService _sceneLoaderService;

        [Inject]
        private CatSceneModel _catSceneModel;
        public async Task StartAsync(CancellationToken cancellation = default)
        {
            await InitializeServices();
            await _sceneLoaderService.LoadMainScene();
        }

        private async UniTask InitializeServices()
        {
            _catSceneModel.InitializationProgress = 0;
            
            if (_userAuthorizationService == null)
                throw new Exception("userAuthorizationService is null");

            _catSceneModel.InitializationProgress = 0.25f;
            
            Debug.Log("userAuthorizationService start loading");
            await _userAuthorizationService.Connect();
            Debug.Log("userAuthorizationService loaded");

            _catSceneModel.InitializationProgress = 0.5f;
            
            Debug.Log("gameEntityDataBaseService start loading");
            await _gameEntityDataBaseService.Update();
            Debug.Log("gameEntityDataBaseService loaded");
        }
    }
}