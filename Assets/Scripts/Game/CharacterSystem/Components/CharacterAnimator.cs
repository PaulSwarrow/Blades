using CharacterSystem.Data;
using CharacterSystem.Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterAnimator : MonoBehaviour, ICharacterAnimator
    {
        public static readonly int ForceAttack = Animator.StringToHash("ForceAttack");
        private static readonly int Forward = Animator.StringToHash("forward");
        private static readonly int Strafe = Animator.StringToHash("strafe");
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int Walk = Animator.StringToHash("walk");
        
        private Animator animator;
        private CharacterContext context;
        private int animationTrigger;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }


        public void ApplyContext(CharacterContext context)
        {
            this.context = context;
        }

        private void Update()
        {
            animationTrigger = -1;
            animator.SetFloat(Forward, context.input.Move.y);
            animator.SetFloat(Strafe, context.input.Move.x);
            animator.SetBool(Grounded, context.physics.grounded);
            animator.SetBool(Walk, context.input.Move.magnitude > 0);

            if (animationTrigger >= 0)
            {
                animator.SetBool(animationTrigger, false);
            }
            
            animationTrigger = context.input.AnimationTrigger;
            if (animationTrigger >= 0)
            {
                animator.SetBool(animationTrigger, true);
            }
        }
    }
}