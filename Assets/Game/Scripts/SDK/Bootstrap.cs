using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Bootstrap : MonoBehaviour
{
    private IEnumerator Start()
    {
        while(YandexGame.SDKEnabled == false)
        {
            yield return null;
        }

        Localization.InitTranslations();
        YandexGame.savesData.LoadPlayerPrefs();
        SceneManager.LoadScene(1);
    }
}
