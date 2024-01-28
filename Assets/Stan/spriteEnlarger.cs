using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteEnlarger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // Adjust this value for the amount of enlargement

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnlargeSprite();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetSpriteScale();
    }

    void EnlargeSprite()
    {
        transform.localScale = originalScale * scaleFactor;
    }

    void ResetSpriteScale()
    {
        transform.localScale = originalScale;
    }
}
