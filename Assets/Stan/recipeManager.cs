using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public GameObject recipePanel;
    public GameObject recipeBook; 
    public GameObject exitButton; 

    private bool isPanelVisible = false; 

    void Start()
    {
        MovePanelOffScreen();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (IsClickOnSprite(clickPosition, recipeBook))
            {
                ShowRecipePanel();
            }
            else if (IsClickOnSprite(clickPosition, exitButton) && isPanelVisible)
            {
                HideRecipePanel();
            }
        }
    }

    void ShowRecipePanel()
    {
        isPanelVisible = true;
        recipePanel.SetActive(true);
        MovePanelOnScreen();
    }

    void HideRecipePanel()
    {
        isPanelVisible = false;
        MovePanelOffScreen();
    }

    void MovePanelOnScreen()
    {
        recipePanel.transform.position = new Vector3(0f, 0f, 0f);
    }

    void MovePanelOffScreen()
    {
        recipePanel.transform.position = new Vector3(2000f, 0f, 0f);
    }
    
    bool IsClickOnSprite(Vector2 clickPosition, GameObject spriteObject)
    {
        if (spriteObject == null)
        {
            Debug.LogError("SpriteObject is null. Please assign a valid GameObject reference.");
            return false;
        }

        Collider2D collider = spriteObject.GetComponent<Collider2D>();
        
        if (collider == null)
        {
            Debug.LogError("Collider2D component is missing on " + spriteObject.name);
            return false;
        }

        return collider.bounds.Contains(clickPosition);
    }
}
