using UnityEngine;

namespace memory.testing.data
{
    public class PlyerData
    {
        public void SavePlayerProgress(int levelNumber)
        {
            PlayerPrefs.SetInt(PlayerPrefConstants.PLAYER_LEVE, levelNumber);
        }

        public int GetLastPLayedLevel()
        {
            return PlayerPrefs.GetInt(PlayerPrefConstants.PLAYER_LEVE, 0);
        }

    }

    public class PlayerPrefConstants
    {
        /// <summary>
        /// To save the player level in player pref using this key.
        /// </summary>
        internal const string PLAYER_LEVE = "player_level";

    }
}
