using UnityEngine;

namespace StarCatcher.Utility
{
    public static class RendererExtensions 
    {
        public static void SetRandomSprite(SpriteRenderer spriteRenderer, Sprite[] sprites)
        {
            if (spriteRenderer == null || sprites == null)
            {
                return;
            }

            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
        
    }
}
