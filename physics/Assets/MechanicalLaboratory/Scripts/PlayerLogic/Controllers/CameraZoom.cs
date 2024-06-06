using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Controllers
{
    public class CameraZoom : ICameraZoom
    {
        private float _fieldOfView = 27.0f;
        private const float _zoomSpeed = 5.0f;

        private Camera _camera;

        public void Init(Camera camera)
        {
            _camera = camera;
        }
        
        public void Zoom()
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                _fieldOfView += -Input.mouseScrollDelta.y * _zoomSpeed;
                if (_fieldOfView < 5) _fieldOfView = 5;
                if (_fieldOfView > 35) _fieldOfView = 35;

                _camera.fieldOfView = _fieldOfView;
            }
        }
    }
}
