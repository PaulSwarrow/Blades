using CharacterSystem.Data;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterEntity : MonoBehaviour
    {
        public CharacterContext context;
        private CharacterAnimator animator;

        private void Awake()
        {
            animator = GetComponent<CharacterAnimator>();
            animator.ApplyContext(context);
        }
    }
}