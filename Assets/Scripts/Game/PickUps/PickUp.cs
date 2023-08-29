using StarCatcher.Game.Services;
using UnityEngine;

namespace StarCatcher.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Variables

        [Header("Pick up option")]
        [SerializeField] private AudioClip _audioClip;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.Platform))
            {
                return;
            }
            ;
            PerformActions(other.gameObject);
            Destroy(gameObject);
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions(GameObject otherColider)
        {
            PlayAudio();
        }

        #endregion

        #region Private methods

        private void PlayAudio()
        {
            AudioService.Instance.PlayAudio(_audioClip);
        }

        #endregion
    }
}