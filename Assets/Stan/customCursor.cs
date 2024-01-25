using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D customCursorTexture;

    void Start()
    {
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }
    public void ResetToCustomCursor()
    {
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
