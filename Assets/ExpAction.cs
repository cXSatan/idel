using TMPro;
using UnityEngine;

public class ExpAction : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float lifetime = 1f;

    public GameObject Text;

    private RectTransform rectTransform;
    private TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = Text.GetComponent<RectTransform>();
        text = Text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move up over time
        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

        // Fade out (optional)
        Color color = text.color;
        color.a -= Time.deltaTime / lifetime;
        text.color = color;

        // Destroy after lifetime
        if (color.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string message)
    {
        text.text = message;
    }
}
