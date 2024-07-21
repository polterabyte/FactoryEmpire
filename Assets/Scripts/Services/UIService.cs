using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;
using VContainer;

namespace Services
{
    public class UIService : IDisposable
    {
        private readonly IObjectResolver _resolver;
        private IScreen _currentScreen;

        public UIService(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void Initialize()
        {
            var activeScreens = GetScreens().Where(x => x.IsActive).ToList();

            if (activeScreens.Count() > 1)
                throw new Exception("Active screens more 1");

            if (activeScreens.Count() == 1)
                _currentScreen = activeScreens.First();
        }
        public void ShowScreen<T>() where T: IScreen
        {
            var screen = GetScreens().FirstOrDefault(x=> x is T);
            
            if (screen == null)
            {
                Debug.Log($"Screen of {typeof(T).Name} not found");
                return;
            }
            
            _currentScreen?.Hide();
            _currentScreen = screen;
            _currentScreen.Show();
        }

        IReadOnlyList<IScreen> GetScreens() => _resolver.Resolve<IReadOnlyList<IScreen>>();

        public void Dispose()
        {
            Debug.Log("Dispose");
        }
    }
}