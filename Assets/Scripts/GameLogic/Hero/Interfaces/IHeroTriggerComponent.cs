using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public interface IHeroTriggerComponent : IHeroComponent
    {
        void Init(LayerMask enemyLayer);
        Transform GetClosetTarget();
    }
}