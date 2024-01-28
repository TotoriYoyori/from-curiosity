using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D customCursorTexture;
    public Vector2 hotspot = Vector2.zero;

    void Start()
    {
        SetCustomCursor(customCursorTexture, hotspot);
    }

    public void SetCustomCursor(Texture2D cursorTexture, Vector2 customHotspot)
    {
        customCursorTexture = cursorTexture;
        hotspot = customHotspot;

        Cursor.SetCursor(customCursorTexture, hotspot, CursorMode.Auto);
    }

    public void ResetToCustomCursor()
    {
        SetCustomCursor(customCursorTexture, hotspot);
    }
}
