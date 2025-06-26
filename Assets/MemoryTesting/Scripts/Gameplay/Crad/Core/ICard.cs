using memory.testing.card;
using memory.testing.pooling;

namespace memory.testing.core
{
    public interface ICard
    {
        Card Card { get; set; }
        CardPooling CardPool { get; set; }
        Card GetCurrentCard();
    }
}