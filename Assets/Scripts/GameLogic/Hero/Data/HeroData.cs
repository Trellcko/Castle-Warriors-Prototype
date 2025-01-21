using UnityEngine;

namespace CastleWarriors.GameLogic.Data
{
    public abstract class HeroData : ScriptableObject
    {
        [field: SerializeField] public HeroType HeroType { get; set; }
        [field: SerializeField] public GameObject HeroPrefab { get; set; }
        
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
    }
}
