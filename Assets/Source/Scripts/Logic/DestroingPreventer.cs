using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts
{
    public class DestroingPreventer : MonoSingleton<DestroingPreventer>
    {
        protected override void AwakeAfter()
        {
            DontDestroyOnLoad(this);
        }
    }
}