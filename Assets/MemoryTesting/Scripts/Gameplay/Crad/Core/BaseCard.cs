using memory.testing.card;
using memory.testing.pooling;

namespace memory.testing.core
{
    public class BaseCard : ICard
    {
        #region Properties
        public Card Card { get; set; }
        public CardPooling CardPool { get; set; }
        #endregion

        #region IFlipCard Implementation
        public virtual Card GetCurrentCard() => Card;
        #endregion
    }

}
