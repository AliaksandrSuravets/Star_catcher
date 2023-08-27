using StarCatcher.Game.Services;
using UnityEngine;

namespace StarCatcher.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            if (GameService.Instance.IsGameOver)
            {
                return;
            }

            MoveWithMouse();
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