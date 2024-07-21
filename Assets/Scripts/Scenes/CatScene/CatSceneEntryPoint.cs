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
            
            Debug.Log("userAuthorizationService start loading");
            _catSceneModel.InitializationProgress = 0.5f;
            await _userAuthorizationService.Connect();
            _catSceneModel.InitializationProgress = 1;
            Debug.Log("userAuthorizationService loaded");
        }
    }
}