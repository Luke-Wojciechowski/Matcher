using System;
using UnityEngine;

namespace Source.Scripts.GUI
{
    public class TutorialGuide : MonoBehaviour
    {
        private void Start()
        {
            HideGuide();
        }

        public void HideGuide()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 10000, 0);
        }
        public void DisplayGuide()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1400, 0);
        }
    }
}