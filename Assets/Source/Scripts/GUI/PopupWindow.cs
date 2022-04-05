using System;
using Ingame;
using Ingame.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.GUI
{
    public class PopupWindow: MonoBehaviour
    {
        private void OnEnable()
        {
            Hide();
            Timer.OnTimeOut += Display;
            GameLogicManager.OnStartGame += Hide;
        }

        private void OnDisable()
        {
            Timer.OnTimeOut -= Display;
            GameLogicManager.OnStartGame -= Hide;
        }

        private void Display()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1500, 0);
        }

        private void Hide()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 10000, 0);
        }
    }
}