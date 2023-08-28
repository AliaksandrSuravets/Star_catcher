using System;
using StarCatcher.Game.Services;
using UnityEngine;

namespace StarCatcher.Game
{
    public class Platform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _maxScaleX;
        [SerializeField] private float _minScalex;

        private Vector3 _startScale;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startScale = transform.localScale;
            GameService.Instance.OnHpOver += OnHpOver;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnHpOver -= OnHpOver;
        }

        private void OnHpOver()
        {
            transform.localScale = _startScale;
        }

        private void Update()
        {
            if (GameService.Instance.IsGameOver)
            {
                return;
            }

            MoveWithMouse();
        }

        #endregion

        #region Public methods

        public void ChangeScale(float valueChange)
        {
            float scaleX = transform.localScale.x;
            float cangeScaleX = (_startScale.x * valueChange) / 100;
            float newScaleX = Mathf.Clamp(scaleX + cangeScaleX, _minScalex, _maxScaleX);
            Vector3 localScale = new Vector3(newScaleX , transform.localScale.y, transform.localScale.z);
            transform.localScale = localScale;
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 currentPosition = transform.position;
            currentPosition.x = worldMousePosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}