using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public interface IHeroTriggerComponent : IHeroComponent
    {
        void SetOpponentLayerMask(LayerMask enemyLayer);
        Transform GetClosetOpponent();
    }
}