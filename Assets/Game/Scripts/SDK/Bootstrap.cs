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
        SceneManager.LoadScene(1);
    }
}
