using System;
using Ingame.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class ScoreBoard : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = this.CheckAndGetComponent<Text>();
        }

        private void OnEnable()
        {
            Timer.OnTick += ModifyCurrentDisplayedScore;
        }

        private void OnDisable()
        {
            Timer.OnTick -= ModifyCurrentDisplayedScore;
        }

        private void ModifyCurrentDisplayedScore()
        {
            _text.text = Score.Instance.Points.ToString();
        }
    }
}