using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ingame
{
    public class CharacterManager : MonoSingleton<CharacterManager>
    {
        [SerializeField] private List<SpritesOnUnlock> _spritesToUnlock;
        
        public List<SpriteRenderer> GetSimplifyList()
        {
            var l = new List<SpriteRenderer>();
            foreach (var i in _spritesToUnlock)
            {
                foreach (var j in i.Sprites)
                {
                    l.Add(j);
                }    
            }
            return l;
        }
        public static SpriteRenderer GetRandom(List<SpriteRenderer> renderers)
        {
            if (renderers.Count <= 0)
            {
                return null;
            }

            int index = (int) Random.Range(0, renderers.Count);
            return renderers[index];
        }
    }
}