using UnityEngine;
using Random = UnityEngine.Random;

namespace StarCatcher
{
    public class CelestialBodie : MonoBehaviour
    {
        #region Variables

        [Header("Sprite")]
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetSprite();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Platform"))
            {
                return;
            }

            Destroy(gameObject);
        }

        #endregion

        #region Private methods

        private void SetSprite()
        {
            if (_spriteRenderer == null || _sprites == null)
            {
                return;
            }

            _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
            gameObject.AddComponent<PolygonCollider2D>();
        }

        #endregion
    }
}