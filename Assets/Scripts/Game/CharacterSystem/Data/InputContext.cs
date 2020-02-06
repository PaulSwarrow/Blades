using System;
using UnityEngine;

namespace CharacterSystem.Data
{
    [Serializable]
    public struct CharacterInput
    {
        public Vector3 Move;
        public bool JumpTrigger;
        public int AnimationTrigger;
        public Vector3 LookDrirection;
    }
}