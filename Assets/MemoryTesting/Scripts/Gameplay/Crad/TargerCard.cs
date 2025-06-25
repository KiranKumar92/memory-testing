using UnityEngine;
using memory.testing.core;
using memory.testing.pooling;

namespace memory.testing.card
{
    public class TargerCard : BaseCard
    {
        public TargerCard(Sprite matchImageSprite,int currentID, CardPooling cardPooling)
        {
            CardPool = cardPooling;
            Card = CardPool.CardPool.Get();
            Card.gameObject.SetActive(false);
            Card.SetProperties(matchImageSprite,currentID,typeof(TargerCard));
        }
    }
}
