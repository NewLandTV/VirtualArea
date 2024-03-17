using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    // Components
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        KeepInScreen();
    }

    private void KeepInScreen()
    {
        Rect rect = rectTransform.rect;
        Vector2 leftBottom = transform.TransformPoint(rect.min);
        Vector2 rightTop = transform.TransformPoint(rect.max);
        Vector2 uiSize = rightTop - leftBottom;

        rightTop = new Vector2(Screen.width, Screen.height) - uiSize;

        float x = Mathf.Clamp(leftBottom.x, 0f, rightTop.x);
        float y = Mathf.Clamp(leftBottom.y, 0f, rightTop.y);

        Vector2 offset = (Vector2)rectTransform.position - leftBottom;

        rectTransform.position = new Vector2(x, y) + offset;
    }
}
