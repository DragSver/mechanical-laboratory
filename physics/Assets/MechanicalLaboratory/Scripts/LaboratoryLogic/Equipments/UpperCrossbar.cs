using System.Collections.Generic;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class UpperCrossbar : Interactable, IComposableParent
    {
        [SerializeField] private InformationWindowTripod _informationWindowTripod;
        
        public List<IComposableChild> ComposableChild { get; set; } = new();
        
        public float Height => transform.localPosition.y;
        public float Rotate => transform.localEulerAngles.y;

        private const float _minHeight = 0.06f;
        private const float _maxHeight = 0.3f;
        private const float _minRotate = -180f;
        private const float _maxRotate = 180f;


        protected override void Awake()
        {
            base.Awake();
            
            _informationWindowTripod.InitUpperCrossbarSliders(
                _minHeight, 
                _maxHeight, 
                _minRotate, 
                _maxRotate);
            
            SetHeight(0.2f);
            SetRotate(0);
        }
        
        public void SetHeight(float height)
        {
            height = Mathf.Clamp(height, _minHeight, _maxHeight);

            transform.localPosition = new Vector3(
                transform.localPosition.x,
                height,
                transform.localPosition.z);

            foreach (var composableChild in ComposableChild)
                composableChild.ConditionUpdate();
            
            _informationWindowTripod.UpdateHeightSliderUpperCrossbar(Height);
        }
        public void SetRotate(float rotate)
        {
            rotate = Mathf.Clamp(rotate, _minRotate, _maxRotate);

            transform.localRotation = 
                Quaternion.Euler(0, rotate, 0);

            _informationWindowTripod.UpdateRotateSliderUpperCrossbar(rotate);
        }
    }
}