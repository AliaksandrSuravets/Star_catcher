using System;
using StarCatcher.Utility;
using UnityEngine;

namespace StarCatcher.Game.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private int _startHp = 3;

        #endregion

        #region Events

        public event Action OnChangeHP;
        public event Action OnChangeScore;

        public event Action OnHpOver;
        public event Action OnStartGameService;

        #endregion

        #region Properties

        public int Hp { get; private set; }
        public bool IsGameOver { get; private set; }
        public int Score { get; private set; }

        #endregion

        #region Unity lifecycle

        public void Reset()
        {
            Hp = _startHp;
            Score = 0;
            IsGameOver = false;
            OnStartGameService?.Invoke();
        }

        private void Start()
        {
            Reset();
        }

        #endregion

        #region Public methods

        public void ChangeHP(int value)
        {
            Hp += value;
            OnChangeHP?.Invoke();
            if (Hp <= 0)
            {
                IsGameOver = true;
                OnHpOver?.Invoke();
            }
        }

        public void ChangeScore(int value)
        {
            Score = Mathf.Max(0, Score + value);
            OnChangeScore?.Invoke();
        }

        #endregion
    }
}