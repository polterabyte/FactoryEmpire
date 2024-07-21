using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;

public static class AppStart
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void InitUniTaskLoop()
    {
        var loop = PlayerLoop.GetCurrentPlayerLoop();
        Cysharp.Threading.Tasks.PlayerLoopHelper.Initialize(ref loop);
    }
        
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void Initialize()
    {
//        GameObject.DontDestroyOnLoad(GameObject.Instantiate(Resources.Load("[PROJECTCONTEXT]")));
        //SystemSetups();
#if UNITY_EDITOR
        //SceneManager.LoadScene("CatScene");
#endif
        //Noesis.GUI.SetLicense("gusunsun", "bGi0xp4ktMbtPHtQz7bWIj3jR888a+NiQgsAxqy+liRMGefb");
        //Noesis.GUI.SetLoadAssemblyCallback(LoadAssemblyCallback);
    }



    static void SystemSetups()
    {
        Screen.SetResolution(1080, 1920, true);
        Application.targetFrameRate = -1;
        Time.fixedDeltaTime = 1 / 32f;
    }

    static void LoadAssemblyCallback(string asm) 
    {
        Debug.Log(asm);
    }
}
