using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color finalColor;
    [SerializeField] Renderer objectRenderer;

    Color startColor;

    void Start()
    {
        startColor = objectRenderer.material.color;
    }
    public void ChangeColor(float t)
    {
        objectRenderer.material.color = Color.Lerp(startColor, finalColor, t);
    }

    private void OnValidate()
    {
        if(objectRenderer == null)
            objectRenderer = GetComponent<Renderer>();
    }
}