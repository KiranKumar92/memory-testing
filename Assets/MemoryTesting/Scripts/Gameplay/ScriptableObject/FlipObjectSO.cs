using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memory.testing.card
{
     [CreateAssetMenu(fileName = "FlipObjectData", menuName = "ScriptableObjects/Card/FlipObjectSO")]

    public class FlipObjectSO:ScriptableObject
    {
        public FlipCardObjectData[] fObjects;
    }

    [Serializable]
    public class FlipCardObjectData
    { 
        public int fObjectID;
        public Sprite fObjectSprite;
    }
}
