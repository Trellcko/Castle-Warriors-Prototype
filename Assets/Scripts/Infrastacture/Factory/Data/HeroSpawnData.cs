using UnityEngine;

namespace CastleWarriors.Infastructure.Factory.Data
{
    public struct HeroSpawnData
    {
        public Vector3 Position;
        public Quaternion Quaternion;
        public readonly Transform Parent;

        public readonly Transform OpponentTarget;
        
        public HeroSpawnData(Vector3 position, Quaternion quaternion, 
            Transform parent, Transform opponentTarget)
        {
            Position = position;
            Quaternion = quaternion;
            Parent = parent;
            OpponentTarget = opponentTarget;
        }
    }
}