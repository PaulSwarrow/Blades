using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem.Controllers
{
    public class UserCharacterController : MonoBehaviour
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

        [SerializeField] private CharacterEntity target;

        public class Motion
        {
            public int trigger;
        }

        private Dictionary<int, Motion> motionMap = new Dictionary<int, Motion>();
        private InputContext context = new InputContext();

        private void Awake()
        {
            motionMap[listeners[0].hash] = new Motion
            {
                trigger = CharacterAnimator.ForceAttack
            };
        }

        private void Update()
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