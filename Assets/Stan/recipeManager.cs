using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public GameObject recipePanel;
    public Button recipeBookButton;
    public GameObject exitButton;

    public bool isPanelVisible = false;

    public AudioSource SFX_AudioSource;
    public AudioClip pageSound;

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
        PlaySound();
    }

    public void HideRecipePanel()
    {
        isPanelVisible = false;
        recipePanel.SetActive(false);
        MovePanelOffScreen();
        PlaySound();
    }

    void PlaySound()
    {
        SFX_AudioSource.PlayOneShot(pageSound, 0.5f);
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
