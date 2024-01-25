using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public GameObject recipePanel; // Reference to the GameObject for the recipe panel
    public GameObject recipeBook; // Reference to the GameObject for the recipe book sprite
    public GameObject exitButton; // Reference to the GameObject for the exit button sprite

    private bool isPanelVisible = false; // Flag to track whether the panel is currently visible

    void Start()
    {
        // Initially hide the recipe panel outside the screen
        MovePanelOffScreen();
    }

    void Update()
    {
        // Check for mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Convert screen coordinates to world coordinates
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the click hits the recipe book sprite
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

    // Toggle the recipe panel visibility and move it on/off screen
    void ShowRecipePanel()
    {
        isPanelVisible = true;
        recipePanel.SetActive(true);
        MovePanelOnScreen();
    }

    // Hide the recipe panel and move it off-screen
    void HideRecipePanel()
    {
        isPanelVisible = false;
        MovePanelOffScreen();
    }

    // Move the recipe panel onto the screen
    void MovePanelOnScreen()
    {
        // Set the position to the desired on-screen location (adjust as needed)
        recipePanel.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Move the recipe panel off-screen
    void MovePanelOffScreen()
    {
        // Set the position to a location outside the screen (adjust as needed)
        recipePanel.transform.position = new Vector3(2000f, 0f, 0f);
    }

    // Check if the click position is on a sprite
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
