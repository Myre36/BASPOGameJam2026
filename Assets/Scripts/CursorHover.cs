using UnityEngine;
using UnityEngine.EventSystems;

public class CursorHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Texture2D normalCursor;
    [SerializeField]
    private Texture2D hoverCursor;
    [SerializeField]
    private Vector2 hotspot = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Passing 'null' reverts the cursor back to the default system or project cursor
        Cursor.SetCursor(normalCursor, hotspot, CursorMode.Auto);
    }

    private void OnDisable()
    {
        // Resets the cursor if the button is disabled or hidden while hovered
        Cursor.SetCursor(normalCursor, hotspot, CursorMode.Auto);
    }
}
