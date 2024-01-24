using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D customCursorTexture;

    void Start()
    {
        // Set the custom cursor at the start
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }

    // Method to reset the cursor to the custom cursor
    public void ResetToCustomCursor()
    {
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
