using TMPro;
using UnityEngine;

namespace CastleWarriors.Utils
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private float deltaTime;

        void Update()
        {
            deltaTime = Time.unscaledDeltaTime;
        }

        void OnGUI()
        {
            float fps = 1.0f / deltaTime;
            text.SetText($"FPS: {Mathf.Ceil(fps)}");
        }
    }
}
