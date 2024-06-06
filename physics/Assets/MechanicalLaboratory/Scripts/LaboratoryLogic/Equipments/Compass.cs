using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Compass : Pickable, IComposableChild
    {
        [SerializeField] private GameObject _firstCompassFoot;
        [SerializeField] private GameObject _secondCompassFoot;
        
        public IComposableParent ComposableParent { get; set; }

        public ActionResult<string> ComposedWithParent(IComposableParent composableParent)
        {
            if (composableParent is Paper paper)
            {
                InHand = false;
                
                ComposableParent = composableParent;
                ComposableParent.ComposedWithChild(this);
                
                transform.SetParent(paper.transform);
                transform.localPosition = new Vector3(0, 0.105f, 0);
                transform.localRotation = Quaternion.identity;
                
                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            
            return ActionResult<string>.FailureUnsuitableObject();
        }

        public void ConditionUpdate()
        {
            return;
        }
    }
}