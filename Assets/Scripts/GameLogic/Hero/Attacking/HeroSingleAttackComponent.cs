using UnityEngine;

namespace CastleWarriors.GameLogic.Hero.Attacking
{
    public class HeroSingleAttackComponent : MonoBehaviour, IHeroAttackComponent
    {
        public bool IsActive { get; set; } = true;

        public void Attack()
        {
            
        }
    }
}
