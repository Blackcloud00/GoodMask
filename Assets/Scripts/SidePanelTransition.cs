using UnityEngine;
using DG.Tweening;

public class SidePanelTransition : MonoBehaviour
{
    public RectTransform panel;
    public float delay = 1f;
    public float moveDuration = 0.6f;

    Vector2 hiddenPos;
    Vector2 visiblePos;

    void Awake()
    {
        // Saðda ekran dýþý
        hiddenPos = new Vector2(1920f, 0f);
        visiblePos = Vector2.zero;

        panel.anchoredPosition = hiddenPos;
    }

    public void ShowPanel()
    {
        panel
            .DOAnchorPos(visiblePos, moveDuration)
            .SetDelay(delay)
            .SetEase(Ease.OutCubic);
    }

    public void HidePanel()
    {
        panel
            .DOAnchorPos(hiddenPos, moveDuration)
            .SetEase(Ease.InCubic);
    }
}
