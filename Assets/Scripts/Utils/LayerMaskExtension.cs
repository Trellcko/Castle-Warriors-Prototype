using UnityEngine;

namespace CastleWarriors.Utils
{
    public static class LayerMaskExtension
    {
        public static int GetLayerInteger(this LayerMask mask)
            => (int)Mathf.Log(mask.value, 2);
    }
}