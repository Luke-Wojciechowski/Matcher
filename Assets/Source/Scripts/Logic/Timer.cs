using System;
using System.Collections.Generic;
using Ingame;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class Timer: MonoSingleton<Timer>
    {

        private bool _isActive = false;
        private const float TIME_LIMIT = 60;
        private float _timeLeft = 0;
        public float TimeLeftInPercentage => _timeLeft / TIME_LIMIT;
        public static event Action OnTimeOut;
        public static event Action OnTick;

        private void OnEnable()
        {
            GameLogicManager.OnStartGame += SetActive;
        }

        private void OnDestroy()
        {
            GameLogicManager.OnStartGame -= SetActive;
        }

        private void Update()
        {
            if (_isActive)
            {
                OnTick?.Invoke();
                _timeLeft += Time.deltaTime;
                if (TIME_LIMIT<=_timeLeft)
                {
                    _isActive = false;
                    _timeLeft = 0;
                    OnTimeOut?.Invoke();
                }
            }
        }

        public void SetActive()
        {
            _timeLeft = 0;
            _isActive = true;
        }
    }
}