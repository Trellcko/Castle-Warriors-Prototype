using UnityEngine;

namespace CastleWarriors.GameLogic.Hero.Data
{
    public abstract class HeroData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
    }
}
