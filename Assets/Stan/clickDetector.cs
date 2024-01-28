using UnityEngine;
using UnityEngine.UI;

public class ClickDetector : MonoBehaviour
{
    public RecipeManager recipeManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && recipeManager.isPanelVisible)
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = recipeManager.recipePanel.GetComponent<Collider2D>();
            if (collider != null && !collider.bounds.Contains(clickPosition))
            {
                recipeManager.HideRecipePanel();
            }
        }
    }
}