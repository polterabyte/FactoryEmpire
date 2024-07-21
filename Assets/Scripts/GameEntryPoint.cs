using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameEntryPoint : IAsyncStartable
{


    [Inject]
    private SceneLoaderService _sceneLoaderService;
    public async Task StartAsync(CancellationToken cancellation = default)
    {
        await _sceneLoaderService.LoadStartupScene();
    }
}