using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public interface IHeroTriggerComponent : IHeroComponent
    {
        void SetOpponentLayerMask(LayerMask enemyLayer);
        Transform GetClosetOpponent();
    }
}