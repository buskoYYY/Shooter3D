
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int Health;
        public float Speed;
        public SavesYG()
        {
            Health = 0;
            Speed = 0;
        }

        public void LoadPlayerPrefs()
        {
            PlayerPrefs.SetInt(SaveData.SAVE_ENEMY_HEALTH, Health);
            PlayerPrefs.SetInt(SaveData.SAVE_ENEMY_SPEED, Health);
        }
    }
}
