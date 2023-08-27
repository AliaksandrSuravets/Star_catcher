using StarCatcher.Game.Services;
using UnityEngine;

namespace StarCatcher.Game
{
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.GoodObject))
            {
                GameService.Instance.ChangeHP(-1);
            }

            Destroy(other.gameObject);
        }

        #endregion
    }
}