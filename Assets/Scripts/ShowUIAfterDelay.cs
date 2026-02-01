using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ShowImageAfterDelay : MonoBehaviour
{
    public GameObject uiObj1;
    public GameObject uiObj2;
    public GameObject Slider;
    public Button button1;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;


    Image img1;
    Image img2;

    public float delay = 2f;
    public float fadeDuration = 0.5f;

    void Awake()
    {
        img1 = uiObj1.GetComponent<Image>();
        img2 = uiObj2.GetComponent<Image>();

        SetAlpha(img1, 0);
        SetAlpha(img2, 0);
        SetAlpha(button1.image, 0);

        SetAlphaText(text1, 0);
        SetAlphaText(text2, 0);

        uiObj1.SetActive(false);
        uiObj2.SetActive(false);
    }

    private void SetAlphaText(TextMeshProUGUI text, float a)
    {
        Color c = text.color;
        c.a = a;
        text.color = c;
    }

    public void OnButtonClick()
    {
        uiObj1.SetActive(true);
        uiObj2.SetActive(true);

        DOVirtual.DelayedCall(delay, () =>
        {
            Sequence seq = DOTween.Sequence();

            seq.Join(img1.DOFade(1f, fadeDuration));
            seq.Join(img2.DOFade(1f, fadeDuration));
            seq.Join(button1.image.DOFade(1f, fadeDuration));
            seq.Join(text1.DOFade(1f, fadeDuration));
            seq.Join(text2.DOFade(1f, fadeDuration));

            seq.OnComplete(() =>
            {
                Slider.SetActive(true);
            });
        });

    }

    void SetAlpha(Image img, float a)
    {
        Color c = img.color;
        c.a = a;
        img.color = c;
    }
}
