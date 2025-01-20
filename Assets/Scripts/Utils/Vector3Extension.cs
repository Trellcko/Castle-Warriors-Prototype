using CastleWarriors.Constants;
using UnityEngine;

namespace CastleWarriors.Utils
{
    public static class Vector3Extension
    {
        public static bool IsCloseTo(this Vector3 a, Vector3 b) => 
            a.DistanceSqrTo(b) < MathConstants.Epsilon;

        public static float DistanceSqrTo(this Vector3 a, Vector3 b) =>
            (a - b).sqrMagnitude;
    }
}