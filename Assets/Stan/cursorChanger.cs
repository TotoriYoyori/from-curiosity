using UnityEngine;
using UnityEngine.UI;

public class CursorChanger : MonoBehaviour
{
    public Texture2D customCursorTexture;
    public CustomCursor customCursorScript;

    void OnMouseEnter()
    {
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        customCursorScript.ResetToCustomCursor();
    }
}
