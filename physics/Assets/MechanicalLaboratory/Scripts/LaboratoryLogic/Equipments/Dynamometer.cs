using System;
using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Dynamometer : Pickable, IComposableChild
    {
        private Measurement FMeasurement { get; set; }
        
        [SerializeField] private DynamometerView _dynamometerView;
        
        private const float _g = 9.8f;
        
        public IComposableParent ComposableParent { get; set; }
        
        
        protected override void Awake()
        {
            base.Awake();
            InitMeasurements();
        }
        
        public ActionResult<string> ComposedWithParent(IComposableParent composableParent)
        {
            if (composableParent is Weight weight &&
                weight.ComposableParent is Thread)
            {
                InHand = false;
                
                ComposableParent = composableParent;
                ComposableParent.ComposedWithChild(this);
                
                transform.SetParent(weight.transform);
                
                ConditionUpdate();
                
                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            
            return ActionResult<string>.FailureUnsuitableObject();
        }
        
        public void ConditionUpdate()
        {
            if (ComposableParent is Weight weight && 
                weight.ComposableParent is Thread thread)
            { 
                transform.localPosition = new Vector3(0, 0.0035f, 0.009f);
                transform.localRotation = Quaternion.Euler(0, 90, 90 + thread.Tilt);
            }
            
            UpdateFMeasure();
        }
        
        private void UpdateFMeasure()
        {
            if (ComposableParent is Weight weight
                && weight.ComposableParent is Thread thread
                && thread.ComposableParent is not null)
            {
                var a = _g * thread.Radius / thread.Height;
                var fMeasurement = FMeasurement;
                fMeasurement.Value = (float)Math.Round(a * weight.WeightMeasurement.Value, 3);
                FMeasurement = fMeasurement;

            }
            else
            {
                var fMeasurement = FMeasurement;
                fMeasurement.Value = 0;
                FMeasurement = fMeasurement;
            }
            
            _dynamometerView.CallValue(FMeasurement.Value);
        }

        private void InitMeasurements()
        {
            FMeasurement = CurrentEquipmentData.Measurements
                .Find(x => x.Designation == "F");
        }
    }
}