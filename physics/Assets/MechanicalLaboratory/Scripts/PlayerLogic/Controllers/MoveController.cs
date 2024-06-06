using MechanicalLaboratory.Scripts.PlayerLogic.Data;
using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Controllers
{
    public class MoveController : IMoveController
    {
        private Transform _playerTransform;
        private Quaternion _originalRotation;

        private const float _mouseSensitivity = 2.0f;
        
        private float _speedRotate = 10.0f;
        private const float _speedMove = 5.0f;
        private const float _heightCamera = 140.0f;
        
        private float _cameraRotationX = 0F;
        private float _cameraRotationY = 0F;
        
        public void Init(Transform transformPlayer)
        {
            _playerTransform = transformPlayer;
            _originalRotation = _playerTransform.rotation;
        }
        
        public void UpdateLocation()
        {
            Rotation();
            Move();
        }

        public void Rotation()
        {
            if (Input.GetMouseButtonDown(2))
                Cursor.lockState = CursorLockMode.Locked;
            if (Input.GetMouseButtonUp(2))
                Cursor.lockState = CursorLockMode.None;

            if (Input.GetMouseButton(2))
            {
                _speedRotate = Mathf.Clamp(_speedRotate, 10, 25);
                _speedRotate -= Input.GetAxis("Mouse ScrollWheel") * _speedRotate;

                _cameraRotationX += Input.GetAxis("Mouse X") * _mouseSensitivity;
                _cameraRotationY += Input.GetAxis("Mouse Y") * _mouseSensitivity;
                _cameraRotationX = Mathf.Clamp(
                    _cameraRotationX, 
                    CameraRangeData.MinimumX, 
                    CameraRangeData.MaximumX);
                _cameraRotationY = Mathf.Clamp(
                    _cameraRotationY, 
                    CameraRangeData.MinimumY, 
                    CameraRangeData.MaximumY);
                Quaternion xQuaternion = Quaternion.AngleAxis(_cameraRotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(_cameraRotationY, Vector3.left);
                _playerTransform.rotation = _originalRotation * xQuaternion * yQuaternion;
            }
        }

        public void Move()
        {
            var baseInput = GetBaseInput();
            baseInput *= _speedMove;
            _playerTransform.Translate(baseInput);
            _playerTransform.position = new Vector3(
                _playerTransform.position.x, 
                _heightCamera, 
                _playerTransform.position.z);
        }

        private Vector3 GetBaseInput()
        {
            Vector3 pVelocity = new Vector3();
            if (Input.GetKey(KeyCode.W))
            {
                pVelocity += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                pVelocity += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                pVelocity += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                pVelocity += new Vector3(1, 0, 0);
            }
            return pVelocity;
        }
    }
}
