using UnityEngine;

namespace CastleWarriors.GameLogic.Data
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "SO/HeroFighterData")]
    public class HeroFighterData : HeroData
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float DelayBetweenAttack { get; private set; }
        [field: SerializeField] public int AttackCounts { get; private set; }
        [field: SerializeField] public float TriggerDistance { get; private set; }
        [field: SerializeField] public float DistanceToStartAttack {get; private set;}
    }
}