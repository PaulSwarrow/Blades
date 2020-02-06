using CharacterSystem.Data;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterEntity : MonoBehaviour
    {
        public CharacterContext context;
        private CharacterAnimator animator;
        public object body;

        private void Awake()
        {
            animator = GetComponent<CharacterAnimator>();
            animator.ApplyContext(context);
        }

        public Transform GetBone(HumanBodyBones boneId)
        {
            return animator.GetBone(boneId);
        }
    }
}