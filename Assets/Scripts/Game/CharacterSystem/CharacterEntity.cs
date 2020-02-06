using CharacterSystem.Data;
using CharacterSystem.Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterEntity : MonoBehaviour
    {
        public CharacterContext context;
        private GenericMap<BaseCharacterComponent> components;
        public object body;

        private void Awake()
        {
            components = new GenericMap<BaseCharacterComponent>();
            foreach (var component in GetComponents<BaseCharacterComponent>())
            {
                component.ApplyContext(context);
                components.Set(component);
            }
        }

        public Transform GetBone(HumanBodyBones boneId)
        {
            return components.Get<CharacterAnimator>().GetBone(boneId);
        }
    }
}