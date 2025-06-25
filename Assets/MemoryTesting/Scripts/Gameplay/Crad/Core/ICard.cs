using memory.testing.card;
using memory.testing.pooling;

namespace memory.testing.core
{
    public interface ICard
    {
        Card Card { get; set; }
        CardPooling CardPooling { get; set; }
        Card GetCurrentCard();
    }
}