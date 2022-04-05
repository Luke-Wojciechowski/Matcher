using System;
using System.Collections.Generic;
using Source.Scripts;
using UnityEngine;

namespace Ingame
{
    public sealed class GameLogicManager : MonoSingleton<GameLogicManager>
    {
        public static event Action OnStartGame; 
        public static event Action OnCharacterAppear;
        
        private List<SpriteRenderer> _matches = new List<SpriteRenderer>();
        private List<SpriteRenderer> _all = new List<SpriteRenderer>();
        private SpriteRenderer _current;
        private bool _blockScore = false;
        public SpriteRenderer CurrentSprite => _current;
        protected override void AwakeAfter()
        {
            base.AwakeAfter();
            _all = CharacterManager.Instance.GetSimplifyList();
        }


        private void OnEnable()
        {
            InputManager.OnSlideLeft += RejectFigure;
            InputManager.OnSlideRight += AcceptFigure;
            Timer.OnTick += PerformNonBlocking;
            Timer.OnTimeOut += PerformBlocking;
            
            OnCharacterAppear += AdjustCurrentSpriteRenderer;
            OnStartGame += OnCharacterAppear;
            OnStartGame += ResetMatches;
            AdjustCurrentSpriteRenderer();
        }

        private void OnDisable()
        {
            InputManager.OnSlideLeft -= RejectFigure;
            InputManager.OnSlideRight -= AcceptFigure;
            Timer.OnTick -= PerformNonBlocking;
            Timer.OnTimeOut -= PerformBlocking;
            
            OnCharacterAppear -= AdjustCurrentSpriteRenderer;
            OnStartGame -= OnCharacterAppear;
            OnStartGame -= ResetMatches;
        }

        private void RejectFigure()
        {     
            ModifyScoreOnFigure(true);
        }

        private void AcceptFigure()
        {
            ModifyScoreOnFigure();
        }

        private void ModifyScoreOnFigure(bool reversed = false)
        {
            if (_blockScore)
            {
                return;
            }
            var result = CheckIfSpriteBelongsToSelectedSprites();
            result = !reversed ? result : !result;
            if (result)
            {
                Score.Instance.Increase();
            }
            else
            {
                Score.Instance.Decrease();
            }
            OnCharacterAppear?.Invoke();
        }
        private void ResetMatches()
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
        private void PerformNonBlocking()
        {
            _blockScore = false;
        }
        private void PerformBlocking()
        {
            _blockScore = true;
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
        public void Reset()
        {
            OnStartGame?.Invoke();
        }
        
    }
}
