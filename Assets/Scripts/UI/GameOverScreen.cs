using StarCatcher.Game.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StarCatcher.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentObject;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TMP_Text _gameOverLabel;
        

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _contentObject.SetActive(false);
        }

        private void Start()
        {
            GameService.Instance.OnHpOver += OnHpOver;
            _resetButton.onClick.AddListener(OnClickResetButton);
            _exitButton.onClick.AddListener(OnClickExitButton);
        }

        private void OnDestroy()
        {
            GameService.Instance.OnHpOver -= OnHpOver;
        }

        #endregion

        #region Private methods

        private void OnClickExitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private void OnClickResetButton()
        {
            GameService.Instance.Reset();
            SpawnService.Instance.Reset();
            _contentObject.SetActive(false);
        }

        private void OnHpOver()
        {
            _contentObject.SetActive(true);
            _gameOverLabel.text = $"Game Over! Your score: {GameService.Instance.Score}";
        }

        #endregion
    }
}