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
                    { "����� �����", "����� �����" },
                    { "������", "������" },
                    { "�������", "�������" },
                    { "�������", "�������" },
                    { "��� ������?", "��� ������?" },
                    { "����������", "����������" },
                    { "��������", "��������" },
                    { "�����������", "�����������" },
                    { "����� ������","����� ������" },
                    { "�����","�����" },
                    { "�","�" },
                    { "�","�" },
                    { "�","�" },
                    { "�","�" },
                    { "�","�" },
                    { "�� ���������!","�� ���������!" },
                    { "�������","�������" },
                    { "������� � ����","������� � ����" },
                    { "�� ��������!","�� ��������"! },
                    { "����������","����������" },
                    { "����","����" }
                };
        }
        else
        {
            _translations = new()
                {
                    { "����� �����", "HERO'S TIME" },
                    { "������", "EASY" },
                    { "�������", "MEDIUM" },
                    { "�������", "HARD" },
                    { "��� ������?", "HOW TO PLAY" },
                    { "����������", "CONTROL" },
                    { "��������" , "SHOOTING" },
                    { "�����������" , "RELOADING" },
                    { "����� ������","CHANGING WEAPONS" },
                    { "�����","PAUSE" },
                    { "�","A" },
                    { "�","W" },
                    { "�","S" },
                    { "�","D" },
                    { "�","R" },
                    { "�� ���������!","YOU LOST" },
                    { "�������","RESTART" },
                    { "������� � ����","GO TO MENU" },
                    { "�� ��������!","YOU WON" },
                    { "����������","CONTINUE" },
                    { "����","AUDIO" }
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
