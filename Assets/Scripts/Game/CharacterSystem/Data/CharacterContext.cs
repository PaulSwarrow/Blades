using System;
using Cinemachine;

namespace CharacterSystem.Data
{
    [Serializable]
    public class CharacterContext
    {
        public CharacterInput input;
        public PhysicsContext physics;
        public GameCameraMode cameraMode;
    }
}