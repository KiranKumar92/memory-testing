using memory.testing.events;
using System;
using System.Collections;
using UnityEngine;

namespace memory.testing.card
{
    [RequireComponent(typeof(Card))]
    public class CardMatchSuccess : MonoBehaviour
    {
        #region Serialize Fields
        [Header("LeanTweenSpeed")]
        [SerializeField] private float fullScaleSpeed = 1f;
        [SerializeField] private float shrinkSpeed = 0.2f;
        #endregion

        #region Private Variables
        private Card _currentCard;
        private readonly Vector2 fullScale = new Vector2(1.2f, 1.2f);
        #endregion

        #region Unity Callbacks
        private void Start() => _currentCard = GetComponent<Card>();
        private void OnEnable() => EventsHandler.CardMatchResult += DisableFlipCardMatchResult;
        private void OnDisable() => EventsHandler.CardMatchResult -= DisableFlipCardMatchResult;
        #endregion

        #region Private Methods
        private void DisableFlipCardMatchResult(bool result, int cardId)
        {
            if (_currentCard.isBackFliped && result && cardId == _currentCard.currentID)
            {
                StartCoroutine(nameof(iDelayedCall));
              
                LeanTween.scale(gameObject, fullScale, fullScaleSpeed).setEaseOutBounce().setOnComplete(() =>
                {
                    LeanTween.scale(gameObject, Vector2.zero, shrinkSpeed).setOnComplete(() =>
                    {
                        if (_currentCard.gameObject.activeSelf)
                        {
                            _currentCard.ReturnToPool();
                        }
                    });
                });
            }
        }
        private IEnumerator iDelayedCall()
        {
            yield return new WaitForSeconds(1f);
            _currentCard.isBackFliped = false;
            EventsHandler.FlippedMemoryCard?.Invoke(null, true);
        }
        #endregion
    }
}
