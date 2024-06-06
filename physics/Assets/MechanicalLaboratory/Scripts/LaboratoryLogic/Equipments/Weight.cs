using System.Collections.Generic;
using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Weight : Pickable, IComposableChild, IComposableParent
    {
        [SerializeField] private float _defaultMass;

        public Measurement WeightMeasurement { get; private set; }

        public IComposableParent ComposableParent { get; set; }
        public List<IComposableChild> ComposableChild { get; set; } = new();
        
        
        protected override void Awake()
        {
            base.Awake();
            InitMeasurements();
        }
        
        public ActionResult<string> ComposedWithParent(IComposableParent composableParent)
        {
            if (composableParent is Thread thread && 
                thread.ComposableParent is not null)
            {
                InHand = false;
                
                ComposableParent = composableParent;
                ComposableParent.ComposedWithChild(this);
                
                transform.SetParent(thread.transform);
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
            if (ComposableParent is Thread thread)
            {
                transform.localPosition = new Vector3(0, thread.ScaleY * -1 - 0.021f, 0);
            }

            foreach (var composableChild in ComposableChild)
                composableChild.ConditionUpdate();
        }

        private void InitMeasurements()
        {
            var weightMeasurement = CurrentEquipmentData.Measurements
                .Find(x => x.Designation == "m");
            weightMeasurement.Value = _defaultMass;
            WeightMeasurement = weightMeasurement;
        }
    }
}
