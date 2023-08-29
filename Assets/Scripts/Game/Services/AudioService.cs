using StarCatcher.Utility;
using UnityEngine;

namespace StarCatcher.Game.Services
{
    public class AudioService : SingletonMonoBehaviour<AudioService>
    {
        #region Variables

        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Public methods

        public void PlayAudio(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                return;
            }
            
            Debug.Log("audioClip");
            _audioSource.PlayOneShot(audioClip);
        }

        #endregion
    }
}