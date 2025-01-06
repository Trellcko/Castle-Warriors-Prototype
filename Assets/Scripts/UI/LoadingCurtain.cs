using CastleWarriors.Constants;
using System.Collections;
using UnityEngine;

namespace CastleWarriors.UI
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float hideSpeed = 1.3f;

        public void Show()
        {
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(HideCorun());
        }
        private IEnumerator HideCorun()
        {
            while (canvasGroup.alpha > MathConstants.Epsilon)
            {
                canvasGroup.alpha -= Time.deltaTime * hideSpeed;
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}
