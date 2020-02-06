using System.Collections.Generic;
using Game;
using UnityEngine;

namespace CharacterSystem.Controllers
{
    public class UserCharacterController : BaseGameController
    {
        private class KeyListener
        {
            public string name;
            public int hash;
        }

        private static List<KeyListener> listeners = new List<KeyListener>
        {
            new KeyListener {name = "Fire1", hash = 10}
        };

        public class InputContext
        {
            public float timeRemain;
            public int logLength;
            public int keysLog;
        }

        [SerializeField] public CharacterEntity target;

        public class Motion
        {
            public int trigger;
        }

        private Dictionary<int, Motion> motionMap = new Dictionary<int, Motion>();
        private InputContext context = new InputContext();


        public override void Init(GameManager gameManager)
        {
            motionMap[listeners[0].hash] = new Motion
            {
                trigger = CharacterAnimator.ForceAttack
            };
        }

        public override void Tick(float deltaTime)
        {
            target.context.input.Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            target.context.input.Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            UpdateContext(context);
            if (GetMotionTrigger(context, out var motion))
            {
                target.context.input.AnimationTrigger = motion.trigger;
            }

            Debug.Log(context.keysLog);
        }

        public override void Dispose()
        {
        }

        private void UpdateContext(InputContext context)
        {
            
            foreach (var listener in listeners)
            {
                if (Input.GetButtonDown(listener.name))
                {
                    context.keysLog = context.keysLog * 100 + listener.hash;
                    context.keysLog++;
                    context.timeRemain = 1;
                    return;
                }
            }

            context.timeRemain -= Time.deltaTime;
            if (context.timeRemain <= 0 && context.logLength > 0)
            {
                context.keysLog = (int) (context.keysLog % Mathf.Pow(100, context.logLength - 1));
                context.logLength--;
                context.timeRemain = 1;
            }

        }

        private bool GetMotionTrigger(InputContext context, out Motion motion)
        {
            return motionMap.TryGetValue(context.keysLog, out motion);
        }
    }
}