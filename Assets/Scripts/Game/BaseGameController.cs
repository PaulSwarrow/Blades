using UnityEngine;

namespace Game
{
    public abstract class BaseGameController : MonoBehaviour
    {
        protected GameManager manager { get; private set; }
        public virtual void Init(GameManager gameManager)
        {
            manager = gameManager;
        }


        public abstract void Tick(float deltaTime);

        public abstract void Dispose();
    }
}