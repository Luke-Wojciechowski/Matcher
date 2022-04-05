using System;
using Ingame.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.GUI
{
    public class GraphicalTimer : MonoBehaviour
    {
        private Image _image;

        private void OnEnable()
        {
            _image = this.CheckAndGetComponent<Image>();
            Timer.OnTick += RefreshTime;
            Timer.Instance.SetActive();
        }

        private void OnDisable()
        {
            Timer.OnTick -= RefreshTime;
        }

        private void RefreshTime()
        {
            _image.fillAmount = Timer.Instance.TimeLeftInPercentage;
        }
    }
}