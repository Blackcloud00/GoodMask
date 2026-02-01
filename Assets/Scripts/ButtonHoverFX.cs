using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHoverFX : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public float hoverScale = 1.08f;
    public float duration = 0.15f;

    Vector3 originalScale;
    Tween scaleTween;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        scaleTween?.Kill();
        scaleTween = transform
            .DOScale(originalScale * hoverScale, duration)
            .SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        scaleTween?.Kill();
        scaleTween = transform
            .DOScale(originalScale, duration)
            .SetEase(Ease.OutQuad);
    }
}
