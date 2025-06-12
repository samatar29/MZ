using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class FogOfWar : MonoBehaviour
{

    public Texture2D fogofWarTexture;
    public SpriteMask spriteMask;

    private Vector2 worldScale;
    private Vector2Int pixelScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        pixelScale.x = fogofWarTexture.width;
        pixelScale.y = fogofWarTexture.height;
        worldScale.x = pixelScale.x / 100f * spriteMask.transform.localScale.y;
        worldScale.y = pixelScale.y / 100f * spriteMask.transform.localScale.y;

        for (int i = 0; i < pixelScale.x; i++)
        {
            for (int j = 0; j < pixelScale.y; j++)
            {
                fogofWarTexture.SetPixel(i, j, Color.clear);
            }
        }
    }

    private Vector2Int WorldToPixel(Vector2 position)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        float dx = position.x - transform.position.x;
        float dy = position.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(.5f * pixelScale.x + dx / (pixelScale.x / worldScale.x));
        pixelPosition.y = Mathf.RoundToInt(.5f * pixelScale.y + dy / (pixelScale.y / worldScale.y));

        return pixelPosition;
    }


    public void MakeHole(Vector2 position, float holeRadius)
    {
        Vector2Int pixelPosition = WorldToPixel(position);
        int radius = Mathf.RoundToInt(holeRadius / (pixelScale.x / worldScale.x));
        int px, nx, py, ny, distance;

        for (int i = 0; i < radius; i++)
        {
            distance = Mathf.RoundToInt(Mathf.Sqrt(radius * radius - i * i));
            for (int j = 0; j < distance; j++)
            {
            px = Mathf.Clamp(pixelPosition.x + i, 0, pixelScale.x);
            nx = Mathf.Clamp(pixelPosition.x - i, 0, pixelScale.x);
            py = Mathf.Clamp(pixelPosition.y + i, 0, pixelScale.y);
            ny = Mathf.Clamp(pixelPosition.y - i, 0, pixelScale.y);

            fogofWarTexture.SetPixel(px, py, Color.black);
            fogofWarTexture.SetPixel(nx, py, Color.black);
            fogofWarTexture.SetPixel(px, ny, Color.black);
            fogofWarTexture.SetPixel(nx, ny, Color.black);
            } 
        }
        fogofWarTexture.Apply();
        CreateSprite();
    }

    private void CreateSprite()
    {
        spriteMask.sprite = Sprite.Create(fogofWarTexture, new Rect(0, 0, fogofWarTexture.width, fogofWarTexture.height), Vector2.one * 0.5f, 100f);
    }
}
