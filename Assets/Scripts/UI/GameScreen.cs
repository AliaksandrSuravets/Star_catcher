using System;
using StarCatcher.Game.Services;
using TMPro;
using UnityEngine;

namespace StarCatcher.UI
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _hpLabel;
        [SerializeField] private TMP_Text _scoreLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            UpdateHp();
            UpdateScore();
            GameService.Instance.OnChangeHP += OnChangeHP;
            GameService.Instance.OnChangeScore += OnChangeScore;
            GameService.Instance.OnStartGameService += OnStartGameService;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnChangeHP -= OnChangeHP;
            GameService.Instance.OnChangeScore -= OnChangeScore;
            GameService.Instance.OnStartGameService -= OnStartGameService;
        }

        #endregion

        #region Private methods

        private void OnChangeHP()
        {
            UpdateHp();
        }

        private void OnChangeScore()
        {
            UpdateScore();
        }

        private void OnStartGameService()
        {
            UpdateHp();
            UpdateScore();
        }

        private void UpdateHp()
        {
            _hpLabel.text = $"Hp: {GameService.Instance.Hp}";
        }

        private void UpdateScore()
        {
            _scoreLabel.text = $"Score: {GameService.Instance.Score}";
        }

        #endregion
    }
}