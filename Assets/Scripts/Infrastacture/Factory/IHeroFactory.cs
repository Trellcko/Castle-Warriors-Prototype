using UnityEngine;

namespace CastleWarriors.Infastructure.Factory
{
    public interface IHeroFactory
    {
        GameObject CreateYoungSwordsman(Vector3 position, Quaternion quaternion, Transform parent);
    }
}