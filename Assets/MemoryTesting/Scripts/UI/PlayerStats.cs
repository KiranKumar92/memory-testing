using memory.testing.data;
using memory.testing.events;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace memory.testing
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] Text _matchersCountText, _turnsCountText, _currentLevelText;
        private int _turnsCount = 0, _matchCount = 0;
        PlyerData _playerData;

        #region Unity Callbacks

        private void OnEnable()
        {
            if (_playerData == null)
            {
                _playerData = new PlyerData();
            }
            EventsHandler.CardMatchResult += UpdateUI;
            EventsHandler.CardMatchCount += SetActualMatchCount;
            _turnsCountText.text = $"Attempt\n {_turnsCount}";
            _matchersCountText.text = $"Matches\n {_matchCount}";
            _currentLevelText.text = $"Level\n {_playerData.GetLastPLayedLevel() + 1}";
        }

        private void SetActualMatchCount(int level)
        {
            _turnsCount = 0;
            _matchCount = 0;
            _turnsCountText.text = $"Attempt\n {_turnsCount}";
            _matchersCountText.text = $"Matches\n {_matchCount}";
            _currentLevelText.text = $"Level\n {_playerData.GetLastPLayedLevel() + 1}";
        }

        private void OnDisable()
        {
            EventsHandler.CardMatchResult -= UpdateUI;
            EventsHandler.CardMatchCount -= SetActualMatchCount;
        }

        private void UpdateUI(bool result, int cardId)
        {
            _turnsCountText.text = $"Attempt\n {++_turnsCount}";
            if (result)
            {
                _matchersCountText.text = $"Matches\n {++_matchCount}";
            }
        }

        #endregion
    }
}