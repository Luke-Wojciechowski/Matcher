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
            Score.OnScoreChange += ModifyCurrentDisplayedScore;
            _text.text = "0";
        }

        private void OnDisable()
        {
            Score.OnScoreChange -= ModifyCurrentDisplayedScore;
        }

        private void ModifyCurrentDisplayedScore()
        {
            _text.text = Score.Instance.Points.ToString();
        }
    }
}