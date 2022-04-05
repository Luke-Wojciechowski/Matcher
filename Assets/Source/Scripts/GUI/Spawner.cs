using System;
using System.Collections;
using Ingame;
using UnityEngine;
using Ingame.Extensions;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class Spawner : MonoBehaviour
    {
        private const float TRANSITION_DELAY = .07f;
        private SpriteRenderer _renderer;
        private void OnEnable()
        {
            _renderer= this.CheckAndGetComponent<SpriteRenderer>();
            GameLogicManager.OnCharacterAppear += DisplaySprite;
            DisplaySprite();
        }

        private void OnDisable()
        {
            GameLogicManager.OnCharacterAppear -= DisplaySprite;
        }

        private void DisplaySprite()
        {
            StartCoroutine(DoSpriteTransition());
        }

        private IEnumerator DoSpriteTransition()
        {
            _renderer.sprite = null;
            yield return new WaitForSeconds(TRANSITION_DELAY);
            _renderer.color = GameLogicManager.Instance.CurrentSprite.color;
            _renderer.sprite = GameLogicManager.Instance.CurrentSprite.sprite;
        }
    }
}