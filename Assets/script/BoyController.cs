using UnityEngine;
using UnityEngine.UI;

public class BoyController : MonoBehaviour
{
    public RenderTexture screen;
    public Vector2Int screePixel;
    public float lightLevel;
    public Text lightText;
    public Color color;

    private Texture2D tex;

    void Awake()
    {
        tex = new Texture2D(screen.width, screen.height, TextureFormat.ARGB32, false);
    }

    void Update()
    {
        RenderTexture currentActive = RenderTexture.active;
        RenderTexture.active = screen;
        tex.ReadPixels(new Rect(0, 0, screen.width, screen.height), 0, 0);
        tex.Apply();
        RenderTexture.active = currentActive;
        color = tex.GetPixel(screePixel.x, screePixel.y);

        lightText.gameObject.SetActive(color.grayscale >= lightLevel);
        if (color.grayscale >= lightLevel)
            lightText.color = new Color(1f,1f,1f, color.grayscale);
    }
}
