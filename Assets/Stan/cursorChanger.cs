using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D customCursorTexture;
    public Vector2 hotspot = Vector2.zero;
    public CustomCursor customCursorScript;

    void OnMouseEnter()
    {
        SetCustomCursor(customCursorTexture, hotspot);
    }

    void OnMouseExit()
    {
        customCursorScript.ResetToCustomCursor();
    }

    // Method to set custom cursor with hotspot
    void SetCustomCursor(Texture2D cursorTexture, Vector2 customHotspot)
    {
        customCursorTexture = cursorTexture;
        hotspot = customHotspot;

        Cursor.SetCursor(customCursorTexture, hotspot, CursorMode.Auto);
    }
}
