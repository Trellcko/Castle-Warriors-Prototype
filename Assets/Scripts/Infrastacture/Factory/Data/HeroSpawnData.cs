using UnityEngine;

namespace CastleWarriors.Infastructure.Services.Factory.Data
{
    public struct HeroSpawnData
    {
        public Vector3 Position;
        public Quaternion Quaternion;
        public readonly Transform Parent;

        public readonly Transform OpponentBase;
        public LayerMask OpponentMask;

        public LayerMask MyMask { get; set; }

        public HeroSpawnData(Vector3 position, Quaternion quaternion, 
            Transform parent, Transform opponentBase, LayerMask opponentMask, LayerMask myMask)
        {
            Position = position;
            Quaternion = quaternion;
            Parent = parent;
            OpponentBase = opponentBase;
            OpponentMask = opponentMask;
            MyMask = myMask;
        }
    }
}