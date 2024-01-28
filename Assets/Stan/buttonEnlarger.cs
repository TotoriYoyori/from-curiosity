using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEnlarger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // Adjust this value for the amount of enlargement

    void Start()
    {
        button = GetComponent<Button>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnlargeButton();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetButtonScale();
    }

    void EnlargeButton()
    {
        transform.localScale = originalScale * scaleFactor;
    }

    void ResetButtonScale()
    {
        transform.localScale = originalScale;
    }
}
