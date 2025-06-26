using System;
using UnityEngine;

namespace memory.testing.events
{
    public class EventsHandler
    {
        #region Card Events

        /// <summary>
        /// When card backface is turned this is invoked
        /// </summary>
        public static Action<int, Type> CurrentFlipCardMatch;

        /// <summary>
        /// Invoked once match comparision is done
        /// </summary>
        public static Action<bool> CardMatchResult;

        /// <summary>
        /// When game started it send number of match count need to performed to complete the current level
        /// </summary>
        public static Action<int> CardMatchCount;


        /// <summary>
        /// This will set the intractability of button if Flipped card is same type as listened card then Set button interact false else true
        /// </summary>
        public static Action<Type, bool> FlippedMemoryCard;

        /// <summary>
        /// This will be called once to increase count when match is done,, to reach the actual match
        /// </summary>
        public static Action OnSuccessMatchIncreaseCount;
        #endregion

    }
}
