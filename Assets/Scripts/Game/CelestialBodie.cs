using System;
using StarCatcher.Game.Services;
using StarCatcher.Utility;
using UnityEngine;
using RendererExtensions = StarCatcher.Utility.RendererExtensions;

namespace StarCatcher.Game
{
    public class CelestialBodie : MonoBehaviour
    {
        #region Variables

        [Header("Sprite")]
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Header("Movement")]
        [SerializeField] private int _startSpeed;
        [SerializeField] private int _maxSpeed;
        [Header("Score")]
        [SerializeField] private int _changeScore;

        
        private int _speed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetSprite();
            ChangeSpeed();
        }

        private void Update()
        {
            CalculateMovement();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Platform"))
            {
                return;
            }
            
            GameService.Instance.ChangeScore(_changeScore);
            Destroy(gameObject);
        }

        #endregion

        #region Private methods

        private void CalculateMovement()
        {
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }

        private void ChangeSpeed()
        {
            _speed = Mathf.Clamp(_speed, _startSpeed + SpawnService.Instance.AmountSpawn, _maxSpeed);
        }

        private void SetSprite()
        {
            RendererExtensions.SetRandomSprite(_spriteRenderer, _sprites); // ??
            gameObject.AddComponent<PolygonCollider2D>();
        }

        #endregion
    }
}