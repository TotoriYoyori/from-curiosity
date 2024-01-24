using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    // Reference to the texture for the custom cursor (optional)
    public Texture2D customCursorTexture;

    // Reference to the CustomCursor script
    public CustomCursor customCursorScript;

    void OnMouseEnter()
    {
        // Change cursor when hovering over the GameObject
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        // Reset to the custom cursor when no longer hovering
        customCursorScript.ResetToCustomCursor();
    }
}
