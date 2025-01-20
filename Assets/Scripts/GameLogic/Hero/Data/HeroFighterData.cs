using UnityEngine;

namespace CastleWarriors.GameLogic.Hero.Data
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "SO/HeroFighterData")]
    public class HeroFighterData : HeroData
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float DelayBetweenAttack { get; private set; }
        [field: SerializeField] public float AttackCounts { get; private set; }
        [field: SerializeField] public float TriggerDistance { get; private set; }
    }
}