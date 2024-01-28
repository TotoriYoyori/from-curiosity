using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public GameObject recipePanel;
    public Button recipeBookButton;
    public GameObject exitButton;

    public bool isPanelVisible = false;

    void Start()
    {
        MovePanelOffScreen();
        recipeBookButton.onClick.AddListener(ToggleRecipePanel);
        exitButton.GetComponent<Button>().onClick.AddListener(HideRecipePanel);
        // Add a listener to the main camera for mouse clicks to hide the panel
        Camera.main.gameObject.AddComponent<ClickDetector>().recipeManager = this;
    }

    public void ToggleRecipePanel()
    {
        isPanelVisible = !isPanelVisible;
        if (isPanelVisible)
        {
            ShowRecipePanel();
        }
        else
        {
            HideRecipePanel();
        }
    }

    public void ShowRecipePanel()
    {
        isPanelVisible = true;
        recipePanel.SetActive(true);
        MovePanelOnScreen();
    }

    public void HideRecipePanel()
    {
        isPanelVisible = false;
        recipePanel.SetActive(false);
        MovePanelOffScreen();
    }

    void MovePanelOnScreen()
    {
        recipePanel.transform.position = new Vector3(0f, 0.25f, 0f);
    }

    void MovePanelOffScreen()
    {
        recipePanel.transform.position = new Vector3(2000f, 0f, 0f);
    }
}
