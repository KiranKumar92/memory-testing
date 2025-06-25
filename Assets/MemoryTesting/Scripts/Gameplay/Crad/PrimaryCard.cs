using UnityEngine;
using memory.testing.core;
using memory.testing.pooling;
namespace memory.testing.card
{
    public class PrimaryCard : BaseCard
    {
       public PrimaryCard(Sprite matchImageSprite,int currentID, CardPooling cardPooling)
       {
            CardPool = cardPooling;
            Card = CardPool.CardPool.Get();
            Card.gameObject.SetActive(false);
            Card.SetProperties(matchImageSprite,currentID,typeof(PrimaryCard));
       }
    }
}
