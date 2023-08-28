using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StarCatcher.UI
{
    public class StartScreen : MonoBehaviour
    {

        [SerializeField] private Button _startButton;
        
        #region Unity lifecycle

        private void Start()
        {
            _startButton.onClick.AddListener(OnClickStartButton);
        }

        private void OnClickStartButton()
        {
            SceneManager.LoadScene("GameScene");
        }

        #endregion
    }
}