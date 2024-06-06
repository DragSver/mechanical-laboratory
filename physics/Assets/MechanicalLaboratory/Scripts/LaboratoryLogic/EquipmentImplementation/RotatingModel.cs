using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.PlayerLogic.Controllers;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation
{
    public class RotatingModel : MonoBehaviour, IRotate
    {
        public MoveController MoveController; //добавить инъекцию

        private readonly float _rotationSensitivity = 20;

        private bool _inFocus;
        private bool _isRotates;

        public void Update()
        {
            Rotate();
        }

        public void Rotate()
        {
            if (Input.GetKey(KeyCode.Mouse0) && _inFocus && _isRotates is false)
            {
                _isRotates = true;
                // MoveController.enabled = false;
            }
            if (_isRotates)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSensitivity, Input.GetAxis("Mouse Y") * _rotationSensitivity);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && _isRotates)
            {
                _isRotates = false;
                // MoveController.enabled = true;
            }
        }

        public void OnMouseEnter()
        {
            _inFocus = true;
        }

        public void OnMouseExit()
        {
            _inFocus = false; 
        }
    }
}
