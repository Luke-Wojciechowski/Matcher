using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
    [CreateAssetMenu(fileName = "SpritesOnUnlock",menuName = "Ingame/SpritesOnUnlock")]
    public class SpritesOnUnlock : ScriptableObject
    {
        [SerializeField] private List<SpriteRenderer> _sprites;
        public List<SpriteRenderer> Sprites => _sprites;
    }
}