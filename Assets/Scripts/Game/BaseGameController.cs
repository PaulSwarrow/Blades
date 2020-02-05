using UnityEngine;

namespace Game
{
    public abstract class BaseGameController : MonoBehaviour
    {
        public abstract void Init();
        public abstract void Tick(float deltaTime);

        public abstract void Dispose();
    }
}