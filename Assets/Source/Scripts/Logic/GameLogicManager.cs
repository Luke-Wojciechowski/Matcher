using System;
using System.Collections.Generic;
using Source.Scripts;
using UnityEngine;

namespace Ingame
{
    public sealed class GameLogicManager : MonoSingleton<GameLogicManager>
    {

        public bool BlockScore = false; 
        public static event Action OnStartGame; 
        public static event Action OnCharacterAppear;
        
        private List<SpriteRenderer> _matches = new List<SpriteRenderer>();
        private List<SpriteRenderer> _all = new List<SpriteRenderer>();
        private SpriteRenderer _current;
        private bool s = true;
        public SpriteRenderer CurrentSprite => _current;
        protected override void AwakeAfter()
        {
            base.AwakeAfter();
            _all = CharacterManager.Instance.GetSimplifyList();
        }

        public void Reset()
        {
            OnStartGame?.Invoke();
        }
        private void OnEnable()
        {
            InputManager.OnSlideLeft += RejectSoldier;
            InputManager.OnSlideRight += AcceptSoldier;
            
            OnCharacterAppear += AdjustCurrentSpriteRenderer;
            OnStartGame += OnCharacterAppear;
            OnStartGame += ResetMatches;
            AdjustCurrentSpriteRenderer();
        }

        private void OnDisable()
        {
            InputManager.OnSlideLeft -= RejectSoldier;
            InputManager.OnSlideRight -= AcceptSoldier;
            
            OnCharacterAppear -= AdjustCurrentSpriteRenderer;
            OnStartGame -= OnCharacterAppear;
            OnStartGame -= ResetMatches;
        }

        private void RejectSoldier()
        {     
            if (BlockScore)
            {
                return;
            }
            var result = CheckIfSpriteBelongsToSelectedSprites();
            if (result)
            {
                Score.Instance.Decrease();
            }
            else
            {
                Score.Instance.Increase();
            }
            OnCharacterAppear?.Invoke();
        }

        private void AcceptSoldier()
        {         
            if (BlockScore)
            {
                return;
            }
            var result = CheckIfSpriteBelongsToSelectedSprites();
            if (result)
            {
                Score.Instance.Increase();
            }
            else
            {
                Score.Instance.Decrease();
            }OnCharacterAppear?.Invoke();
        }
        

        public void ResetMatches()
        {
            _matches = new List<SpriteRenderer>();
        }
        private bool CheckIfSpriteBelongsToSelectedSprites()
        {
            if (_current ==null)
            {
                
            }
            foreach (var i in _matches)
            {
                if (_current.sprite == i.sprite && _current.color==i.color)
                {
                    return true;
                }
            }
            return false;
        }

        private void AdjustCurrentSpriteRenderer()
        {
            _current = CharacterManager.GetRandom(_all);
        }
        
        public void AddSpriteRendererToMatches(SpriteRenderer r)
        {
            if (_matches.Count>=3)
            {
                ResetMatches();
            }
            _matches.Add(r);
        }
 
    }
}
