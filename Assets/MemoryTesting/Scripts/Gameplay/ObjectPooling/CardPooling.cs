using UnityEngine;
using memory.testing.card;
using UnityEngine.Pool;

namespace memory.testing.pooling
{
    public class CardPooling : MonoBehaviour
    {
        #region Serialize Field
        [SerializeField] private Card cardPrefab;
        #endregion

        #region Private Varible
        private ObjectPool<Card> _cardPool;
        #endregion

        #region Properties
        public ObjectPool<Card> CardPool => _cardPool;
        
        #endregion

        #region Unity Callbacks

        private void OnEnable() => _cardPool = new ObjectPool<Card>(Create, TakeFromPool, ReturnBackToPool, DestroyThePooledObject, true, 8, 10);

        #endregion

        #region Private Methods

        /// <summary>
        /// Create the object for the pool.
        /// </summary>
        /// <returns></returns>
        private Card Create()
        {
            var Card = Instantiate(cardPrefab,transform);
            Card.SetPool(_cardPool,cardPrefab.transform);
            return Card;
        }
        
        /// <summary>
        /// Get the object from the pool.
        /// </summary>
        /// <param name="card"></param>
        private void TakeFromPool(Card card) => card.gameObject.SetActive(true);

        /// <summary>
        /// Return the object back to the pool.
        /// </summary>
        /// <param name="card"></param>
        private void ReturnBackToPool(Card card)
        {
            card.transform.SetParent(transform);
            card.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Destroy the pooled object.
        /// </summary>
        /// <param name="card"></param>
        private void DestroyThePooledObject(Card card) => Destroy(card.gameObject);

        #endregion

    }
}
