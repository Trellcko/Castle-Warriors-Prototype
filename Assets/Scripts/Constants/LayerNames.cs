using UnityEngine;

namespace CastleWarriors.Constants
{
    public static class LayerNames
    {
        public static readonly LayerMask PlayerLayer = LayerMask.GetMask($"Player");
        public static readonly LayerMask EnemyLayer = LayerMask.GetMask($"Enemy");
    }
}