using memory.testing.events;
using System.Collections;
using UnityEngine;

namespace memory.testing
{
    public class CardLevelHandler : MonoBehaviour
    {
        #region Private Variable

        private int _actualCount;
        private int _currentMatchCount;

        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            EventsHandler.CardMatchCount += SetActualMatchCount;
            EventsHandler.OnSuccessMatchIncreaseCount += CompareCurrentCount;
        }
        private void OnDisable()
        {
            EventsHandler.CardMatchCount -= SetActualMatchCount;
            EventsHandler.OnSuccessMatchIncreaseCount -= CompareCurrentCount;
            _currentMatchCount = 0;
            _actualCount = 0;
        }
        #endregion

        #region Private Methods
        private void SetActualMatchCount(int actualCount)
        {
            _actualCount = actualCount;
        }

        private void CompareCurrentCount()
        {
            _currentMatchCount++;
            if (_currentMatchCount == _actualCount)
            {
                _currentMatchCount = 0;
                _actualCount = 0;
                StartCoroutine(StartAnotherLevelRoutine());
            }
        }

        private IEnumerator StartAnotherLevelRoutine()
        {
            yield return new WaitForSeconds(2f);
            EventsHandler.StartTheCardLevel?.Invoke();
        }

        #endregion
    }
}