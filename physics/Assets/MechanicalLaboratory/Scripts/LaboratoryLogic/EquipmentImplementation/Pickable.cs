using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation
{
    public abstract class Pickable : Interactable, IPickable
    {
        public bool InHand { get; set; }

        private Quaternion _previousRotation;

        public ActionResult<string> PickUp(GameObject hand)
        {
            if (InHand)
                return ActionResult<string>.FailureAlreadyInHand(CurrentEquipmentData.Name);
            
            InHand = true;
            if (_previousRotation.Equals(new Quaternion())) _previousRotation = transform.localRotation;
            transform.SetParent(hand.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            
            return ActionResult<string>.SuccessResult(MethodBase.GetCurrentMethod()?.Name, CurrentEquipmentData.Name);
        }
        public ActionResult<string> PickDown(GameObject parent, Vector3 position)
        {
            if (!InHand)
                return ActionResult<string>.FailureObjectNotInHand(CurrentEquipmentData.Name);
            
            InHand = false;
            transform.SetParent(parent.transform);
            transform.position = position;
            transform.localRotation = _previousRotation;
            
            return ActionResult<string>.SuccessResult(MethodBase.GetCurrentMethod()?.Name, CurrentEquipmentData.Name);
        }
    }
}
