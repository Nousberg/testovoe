using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(Renderer))]
    public class Plant : Summonable
    {
        [Header("Ripening")]
        [SerializeField] private float ripeningDuration;

        [Header("Animation")]
        [SerializeField] private Ease ripeningEase;
        [SerializeField] private Color ripenedColor;
        [SerializeField] private Vector3 ripenedScale;

        public bool Ripened { get; private set; }

        private void Start()
        {
            Renderer renderer = GetComponent<Renderer>();

            Material material = new Material(renderer.material);
            renderer.material = material;

            Sequence animSequence = DOTween.Sequence();

            animSequence.Append(
                material
                .DOColor(ripenedColor, ripeningDuration)
                .SetEase(ripeningEase)
                .SetUpdate(UpdateType.Normal, true)
                );

            animSequence.Join(
                transform
                .DOScale(ripenedScale, ripeningDuration)
                .SetEase(ripeningEase)
                .SetUpdate(UpdateType.Normal, true)
                );

            animSequence.OnComplete(() => Ripened = true);
        }
        private void OnDestroy() => DOTween.Kill(this);
    }
}