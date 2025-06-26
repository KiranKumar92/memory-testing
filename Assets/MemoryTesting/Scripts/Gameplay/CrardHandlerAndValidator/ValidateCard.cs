using memory.testing.events;
using System;
using UnityEngine;

namespace memory.testing.card
{
    [RequireComponent(typeof(Card))]
    public class ValidateCard : MonoBehaviour
    {
        #region Private Variable
        private Card _currentCard;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            EventsHandler.CurrentFlipCardMatch += CompareCard;
            EventsHandler.FlippedMemoryCard += SetBlockCard;
        }
        private void Start()
        {
            _currentCard = GetComponent<Card>();
        }
        private void OnDisable()
        {
            EventsHandler.CurrentFlipCardMatch -= CompareCard;
            EventsHandler.FlippedMemoryCard -= SetBlockCard;
        }
        #endregion

        #region Private Method
        private void CompareCard(int cardID, Type type)
        {
            if (_currentCard.onSuccessMatchCompleted)
                return;
            if (!_currentCard.isBackFliped)
                return;
            if (cardID == _currentCard.currentID)
            {
                if (_currentCard.cardType == type)
                    return;
                EventsHandler.CardMatchResult?.Invoke(true);
            }
            else
            {
                EventsHandler.CardMatchResult?.Invoke(false);
            }
        }
        private void SetBlockCard(Type arg1, bool canRest)
        {
            if (canRest)
            {
                _currentCard.onSuccessMatchCompleted = false;
            }
        }
        #endregion
    }
}
