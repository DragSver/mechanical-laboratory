using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class LowerCrossbar : Interactable
    {
        [SerializeField] private InformationWindowTripod _informationWindowTripod;
        
        public float Height => transform.localPosition.y;
        public float Rotate => transform.localEulerAngles.y;
        
        private const float _minHeight = 0.03f;
        private const float _maxHeight = 0.27f;
        private const float _minRotate = -180f;
        private const float _maxRotate = 180f;
        
        protected override void Awake()
        {
            base.Awake();
            
            _informationWindowTripod.InitLowerCrossbarSliders(
                _minHeight, 
                _maxHeight, 
                _minRotate, 
                _maxRotate);
                
            SetHeight(0.15f);
            SetRotate(0);
        }

        public void SetHeight(float height)
        {
            height = Mathf.Clamp(height, _minHeight, _maxHeight);

            transform.localPosition = new Vector3(
                transform.localPosition.x,
                height,
                transform.localPosition.z);

            _informationWindowTripod.UpdateHeightSliderLowerCrossbar(Height);
        }
        public void SetRotate(float rotate)
        {
            rotate = Mathf.Clamp(rotate, _minRotate, _maxRotate);

            transform.localRotation = 
                Quaternion.Euler(0, rotate, 0);

            _informationWindowTripod.UpdateRotateSliderLowerCrossbar(rotate);
        }
    }
}