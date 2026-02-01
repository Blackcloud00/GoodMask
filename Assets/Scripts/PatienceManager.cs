using UnityEngine;
using UnityEngine.UI;

public class PatienceManager : MonoBehaviour
{
    public Slider patienceSlider;

    [Header("Buttons")]
    public GameObject buttonWhenPatienceOk;
    public GameObject buttonWhenPatienceZero;

    public float maxPatience = 100f;
    public float currentPatience;

    void Start()
    {
        currentPatience = maxPatience;

        patienceSlider.maxValue = maxPatience;
        patienceSlider.value = currentPatience;

        // Baþlangýç durumu
        buttonWhenPatienceOk.SetActive(false);
        buttonWhenPatienceZero.SetActive(false);
    }

    public void DecreasePatience(float amount)
    {
        currentPatience -= amount;
        currentPatience = Mathf.Clamp(currentPatience, 0, maxPatience);

        buttonWhenPatienceOk.SetActive(true);

        patienceSlider.value = currentPatience;

        if (currentPatience <= 0)
        {
            PatienceZero();
        }
    }

    void PatienceZero()
    {
        Debug.Log("Tahammül bitti!");

        buttonWhenPatienceOk.SetActive(false);
        buttonWhenPatienceZero.SetActive(true);
    }
}
