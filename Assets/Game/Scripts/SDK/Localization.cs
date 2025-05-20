using System.Collections.Generic;
using UnityEngine;
using YG;

public class Localization : MonoBehaviour
{
    private static Dictionary<string, string> _translations;

    public static void InitTranslations()
    {
        if (YandexGame.EnvironmentData.language == "ru")
        {
            _translations = new()
                {
                    { "бпелъ цепнъ", "бпелъ цепнъ" },
                    { "кецйхи", "кецйхи" },
                    { "япедмхи", "япедмхи" },
                    { "ръфекши", "ръфекши" },
                    { "йюй хцпюрэ?", "йюй хцпюрэ?" },
                    { "сопюбкемхе", "сопюбкемхе" },
                    { "ярпекэаю", "ярпекэаю" },
                    { "оепегюпъдйю", "оепегюпъдйю" },
                    { "ялемю нпсфхъ","ялемю нпсфхъ" },
                    { "оюсгю","оюсгю" },
                    { "т","т" },
                    { "ж","ж" },
                    { "ш","ш" },
                    { "б","б" },
                    { "й","й" },
                    { "бш опнхцпюкх!","бш опнхцпюкх!" },
                    { "пеярюпр","пеярюпр" },
                    { "оепеирх б лемч","оепеирх б лемч" },
                    { "бш бшицпюкх!","бш бшицпюкх"! },
                    { "опнднкфхрэ","опнднкфхрэ" },
                    { "гбсй","гбсй" }
                };
        }
        else
        {
            _translations = new()
                {
                    { "бпелъ цепнъ", "HERO'S TIME" },
                    { "кецйхи", "EASY" },
                    { "япедмхи", "MEDIUM" },
                    { "ръфекши", "HARD" },
                    { "йюй хцпюрэ?", "HOW TO PLAY" },
                    { "сопюбкемхе", "CONTROL" },
                    { "ярпекэаю" , "SHOOTING" },
                    { "оепегюпъдйю" , "RELOADING" },
                    { "ялемю нпсфхъ","CHANGING WEAPONS" },
                    { "оюсгю","PAUSE" },
                    { "т","A" },
                    { "ж","W" },
                    { "ш","S" },
                    { "б","D" },
                    { "й","R" },
                    { "бш опнхцпюкх!","YOU LOST" },
                    { "пеярюпр","RESTART" },
                    { "оепеирх б лемч","GO TO MENU" },
                    { "бш бшицпюкх!","YOU WON" },
                    { "опнднкфхрэ","CONTINUE" },
                    { "гбсй","AUDIO" }
                };
        }
    }

    public static string GetText(string key)
    {
        if (_translations.ContainsKey(key))
        {
            return _translations[key];
        }
        else
        {
            Debug.LogError($"Translation for {key} not found.");
            return key;
        }
    }
}
