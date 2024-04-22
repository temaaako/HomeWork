using System.Diagnostics;
using UnityEngine;

public class PreLaunchCheck : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void CheckLaunch()
    {
        if (Debugger.IsAttached)
        {
            
            Debugger.Break();
        }
        else
        {
            
            Process.GetCurrentProcess().Kill();
        }
    }
}




