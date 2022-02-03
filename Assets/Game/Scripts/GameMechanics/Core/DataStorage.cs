using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class DataStorage
    {
        private const string Key = "BestTime";

        public void SetBestTime(float bestTime)
        {
            PlayerPrefs.SetFloat(Key, bestTime);
        }

        public float GetBestTime()
        {
            return PlayerPrefs.HasKey(Key) ? PlayerPrefs.GetFloat(Key) : 0f;
        }
    }
}