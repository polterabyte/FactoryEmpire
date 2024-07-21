using Cysharp.Threading.Tasks;

namespace Services
{
    public class SceneLoaderService
    {
        public async UniTask LoadStartupScene()
        {
            await LoadScene(AppSettings.StartupSceneName);
        }
        
        public async UniTask LoadMainScene()
        {
            await LoadScene(AppSettings.MainSceneName);
        }

        private async UniTask LoadScene(string sceneName)
        {
            if (!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals(sceneName))
                await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName).ToUniTask();
            
        }
    }
}