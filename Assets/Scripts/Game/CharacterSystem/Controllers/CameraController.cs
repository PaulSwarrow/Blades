using CharacterSystem.Controllers;
using CharacterSystem.Data;
using Cinemachine;
using Game;
using UnityEngine;

namespace CharacterSystem
{
    public class CameraController : BaseGameController
    {
        [SerializeField] private CinemachineFreeLook FreeLook;
        [SerializeField] private CinemachineVirtualCamera ShoulderCam;
        private UserCharacterController userController;
        private CharacterEntity target;


        public override void Init(GameManager gameManager)
        {
            base.Init(gameManager);
            userController = manager.Controller<UserCharacterController>();
        }

        public override void Tick(float deltaTime)
        {
            if (target && Input.GetButtonDown("Jump"))
            {
                target.context.cameraMode = target.context.cameraMode == GameCameraMode.Shoulder
                    ? GameCameraMode.FreeLook
                    : GameCameraMode.Shoulder;
                SetCamera(target.context.cameraMode == GameCameraMode.FreeLook? (CinemachineVirtualCameraBase) FreeLook: ShoulderCam);
            }
            SetTarget(userController.target);
        }

        private void SetTarget(CharacterEntity characterEntity)
        {
            if(target == characterEntity) return;
            target = characterEntity;
            if(target == null) return;
            SetCamera(characterEntity.context.cameraMode == GameCameraMode.FreeLook? (CinemachineVirtualCameraBase) FreeLook: ShoulderCam);

        }

        private void SetCamera(CinemachineVirtualCameraBase camera)
        {
            camera.Follow = target.transform;
            camera.LookAt = target.GetBone(HumanBodyBones.Neck);

            FreeLook.enabled = camera == FreeLook;
            ShoulderCam.enabled = camera == ShoulderCam;
        }
        public override void Dispose()
        {
        }

        public Vector3 TransformVector(Vector3 move)
        {
            return Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * move;

        }
    }
}