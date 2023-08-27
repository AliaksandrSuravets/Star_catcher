using UnityEngine;

namespace StarCatcher.Utility
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour
    {
        #region Properties

        public static T Instance { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = gameObject.GetComponent<T>();
        }

        #endregion
    }
}