using System;
using System.Collections.Generic;
using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Thread: Pickable, IComposableChild, IComposableParent
    {
        [SerializeField] private InformationWindowThread _informationWindowThread;
        [SerializeField] private GameObject _thread;
        
        public float ScaleY => _thread.transform.localScale.y;
        public float Radius => LengthMeasurement.Value * (float)Math.Sin(Tilt / 180D * Math.PI);
        public float Height => LengthMeasurement.Value * (float)Math.Cos(Tilt / 180D * Math.PI);
        public float Tilt { get; private set; }
        
        private Measurement LengthMeasurement { get; set; }
        
        public IComposableParent ComposableParent { get; set; }
        public List<IComposableChild> ComposableChild { get; set; } = new();
        
        
        protected override void Awake()
        {
            base.Awake();
            InitMeasurements();

            ConditionUpdate();
            SetTilt(0);
        }

        public ActionResult<string> ComposedWithParent(IComposableParent composableParent)
        {
            if (composableParent is UpperCrossbar upperCrossbar)
            {
                InHand = false;
                
                ComposableParent = composableParent;
                ComposableParent.ComposedWithChild(this);

                transform.SetParent(upperCrossbar.transform);
                transform.localRotation = Quaternion.identity;
                
                ConditionUpdate();

                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            
            return ActionResult<string>.FailureUnsuitableObject();
        }

        public void ConditionUpdate()
        {
            SetLength(ScaleY);
        }

        public void SetLength(float length)
        {
            if (ComposableParent is UpperCrossbar upperCrossbar)
                length = Mathf.Clamp(
                    length,
                    _informationWindowThread.MinScale,
                    (upperCrossbar.transform.localPosition.y - 0.04f) / 2f);
            else
                length = 0.02f;
            
            SetScaleTransform(length);
            UpdateLengthMeasure();
            _informationWindowThread.UpdateLengthSlider(length);
            
            if (ComposableParent is UpperCrossbar)
                UpdateTransformCompose();
        }
        private void SetScaleTransform(float scaleY)
        {
            _thread.transform.localScale = new Vector3(
                _thread.transform.localScale.x,
                scaleY,
                _thread.transform.localScale.z);
        }
        
        public void SetTilt(float rotate)
        {
            if (ComposableParent is UpperCrossbar)
                Tilt = Mathf.Clamp(
                    rotate,
                    _informationWindowThread.MinTilt,
                    _informationWindowThread.MaxTilt);
            else
                Tilt = 0;
            
            _informationWindowThread.UpdateTiltSlider(rotate);
            
            if (ComposableParent is UpperCrossbar) 
                UpdateTransformCompose();
        }
        
        private void UpdateTransformCompose()
        {
            var sin = (float)Math.Sin(Tilt / 180D * Math.PI);
            var cos = (float)Math.Cos(Tilt / 180D * Math.PI);
            var y = -1 * (ScaleY - 0.0005f) * cos;
            var z = (ScaleY - 0.0005f) * sin;
            
            transform.localPosition = new Vector3(0.132f, y, z);
            transform.localRotation = 
                Quaternion.Euler(-Tilt, 0, 0);

            foreach (var composableChild in ComposableChild)
            {
                composableChild.ConditionUpdate();
            }
        } 
        
        private void InitMeasurements()
        {
            LengthMeasurement = CurrentEquipmentData.Measurements
                .Find(x => x.Designation == "l");
        }
        private void UpdateLengthMeasure()
        {
            var lMeasurement = LengthMeasurement;
            lMeasurement.Value = ScaleY * 2;
            LengthMeasurement = lMeasurement;
        }
    }
}