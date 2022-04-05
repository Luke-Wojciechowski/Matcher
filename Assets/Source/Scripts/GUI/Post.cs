using System;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Extensions;

namespace Ingame
{

    public class Post : MonoBehaviour
    {
        
        [SerializeField] private SpritesOnUnlock _sprites;
        private SpriteRenderer _spriteRenderer;
        
        private void OnEnable()
        {
            GameLogicManager.OnStartGame += ApplySprite;
            ApplySprite();
        }

        private void OnDisable()
        {
            GameLogicManager.OnStartGame -= ApplySprite;
        }

        private void ApplySprite()
        {
            _spriteRenderer = this.CheckAndGetComponent<SpriteRenderer>();
            var rand = GetRandomSprite();
            _spriteRenderer.sprite = rand.sprite;
            _spriteRenderer.color = rand.color;
            GameLogicManager.Instance.AddSpriteRendererToMatches(rand);
        }
        
        private SpriteRenderer GetRandomSprite()
        {
            var rand = CharacterManager.GetRandom(_sprites.Sprites);
            return rand;
        }
    }
}