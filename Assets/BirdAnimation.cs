using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public int framesPerSecond;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpriteIndex = 0;
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f / framesPerSecond)
        {
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[currentSpriteIndex];
            timer -= 1.0f / framesPerSecond;
        }
    }
}