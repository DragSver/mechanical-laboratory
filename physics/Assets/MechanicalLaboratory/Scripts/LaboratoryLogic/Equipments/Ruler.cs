using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Ruler : Pickable, IComposableChild
    {
        public IComposableParent ComposableParent { get; set; }

        public ActionResult<string> ComposedWithParent(IComposableParent composableParent)
        {
            if (composableParent is Thread ||
                composableParent is Paper)
            {
                InHand = false;

                ComposableParent = composableParent;
                ComposableParent.ComposedWithChild(this);

                if (ComposableParent is Interactable interactable)
                    transform.SetParent(interactable.transform);

                ConditionUpdate();

                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name,
                    CurrentEquipmentData.Name);
            }
            
            return ActionResult<string>.FailureUnsuitableObject();
        }

        public void ConditionUpdate()
        {
            switch (ComposableParent)
            {
                case Thread thread:
                    transform.localRotation = Quaternion.Euler(0, 180, 90);
                    transform.localPosition = new Vector3(0, -0.15f+thread.ScaleY, -0.024f);
                    break;
                case Paper paper:
                    transform.localPosition = new Vector3(0.15f, 0, 0);
                    transform.localRotation = Quaternion.identity;
                    break;
            }
        }
    }
}