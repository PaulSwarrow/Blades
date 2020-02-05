using System;
using UnityEngine;

namespace CharacterSystem.Data
{
    [Serializable]
    public struct CharacterInput
    {
        public Vector2 Move;
        public bool JumpTrigger;
        public int AnimationTrigger;
    }
}