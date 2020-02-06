using CharacterSystem.Data;
using UnityEngine;

namespace CharacterSystem.Interfaces
{
    public abstract class BaseCharacterComponent : MonoBehaviour
    {
        protected CharacterContext context { get; private set; }

        public void ApplyContext(CharacterContext context)
        {
            this.context = context;
        }
        
    }
}