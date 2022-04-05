using System;
using Ingame;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class Score: MonoSingleton<Score>
    {
        private int _points = 0;
        public int Points => _points;
        public static event Action OnScoreChange;

        private void OnEnable()
        {
            GameLogicManager.OnStartGame += Reset;
            Timer.OnTimeOut += Reset;
        }

        private void OnDisable()
        {
            GameLogicManager.OnStartGame -= Reset;
            Timer.OnTimeOut -= Reset;
        }

        public void Increase()
        {
            _points++;
            OnScoreChange?.Invoke();
        }

        public void Decrease()
        {
            _points-=5;
            if (_points<0)
            {
                _points = 0;
            }
            OnScoreChange?.Invoke();
        }

        public void Reset()
        {
            _points = 0;
        }
    }
}