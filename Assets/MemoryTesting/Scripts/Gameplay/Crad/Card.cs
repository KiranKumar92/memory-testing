using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace memory.testing.card
{
    public class Card : MonoBehaviour
    {
        #region Serialize Field
        [SerializeField] private Image matchImage;
        [SerializeField] internal int currentID;
        #endregion

        #region Private Variable for Pooling
        
        private ObjectPool<Card> _cardPool;
        private Transform _transform;
        
        #endregion

        #region Internal Variable
        internal Type cardType;
        internal bool isBackFliped;
        internal bool onSuccessMatchCompleted;
        #endregion

        #region Public Methods
        public void SetProperties(Sprite matchImageSprite,int currentID,Type classType)
        {
            matchImage.sprite = matchImageSprite;
            this.currentID = currentID;
            this.cardType = classType;
        }
        #endregion

        #region Internal methods for Pooling
        
        /// <summary>
        /// Set the pool and transform for the flip card
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="myTransform"></param>
        internal void SetPool(ObjectPool<Card> pool,Transform myTransform)
        {
            this._cardPool = pool;
            _transform = myTransform;
        }
        
        /// <summary>
        /// Return the flip card to the pool
        /// </summary>
        internal void ReturnToPool()
        {
            _cardPool.Release(this);
            transform.localScale = _transform.localScale;
        }
        #endregion

    }
}
