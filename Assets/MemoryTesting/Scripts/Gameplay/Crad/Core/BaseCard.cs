using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using memory.testing.card;
using memory.testing.pooling;

namespace memory.testing.core
{
    public class BaseCard : MonoBehaviour, ICard
    {
        #region Properties
        public Card Card { get; set; }
        public CardPooling CardPooling { get; set; }
        #endregion

        #region IFlipCard Implementation
        public virtual Card GetCurrentCard() => Card;
        #endregion
    }

}
