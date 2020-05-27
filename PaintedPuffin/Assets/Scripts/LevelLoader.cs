using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class LevelLoader : MonoBehaviour
{
    public GameObject popup;
    public GameObject loadingBar;
    public Slider slider;

    void Start()
    {
        if (AndroidRuntimePermissions.CheckPermission("android.permission.ACCESS_FINE_LOCATION") == AndroidRuntimePermissions.Permission.Granted || AndroidRuntimePermissions.CheckPermission("android.permission.ACCESS_FINE_LOCATION") == AndroidRuntimePermissions.Permission.Denied)
        {
            popup.SetActive(false);
            loadingBar.SetActive(true);
            LoadLevel(1);
        }
        else
        {
            popup.SetActive(true);
        }
    }

    public void GetPermissions()
    {
#if PLATFORM_ANDROID
        AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission("android.permission.ACCESS_FINE_LOCATION");
        if (result == AndroidRuntimePermissions.Permission.Granted || result == AndroidRuntimePermissions.Permission.Denied)
        {
            popup.SetActive(false);
            loadingBar.SetActive(true);
            LoadLevel(1);
        }
#endif
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://painted-puffin.flycricket.io/privacy.html");
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}
