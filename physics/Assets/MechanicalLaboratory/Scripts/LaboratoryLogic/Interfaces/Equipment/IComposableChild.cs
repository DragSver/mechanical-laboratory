using System;
using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment
{
    public interface IComposableChild : IPickable
    {
        public IComposableParent ComposableParent { get; set; }

        
        public ActionResult<string> ComposedWithParent(IComposableParent composableParent);
        
        public ActionResult<string> SeparateAndPickUp(GameObject hand)
        {
            try
            {
                SeparateParent();
                PickUp(hand);
                
                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            catch (Exception e)
            {
                return new ActionResult<string>(false, e.Message);
            }
        }
        public ActionResult<string> SeparateParent()
        {
            try
            {
                ComposableParent.SeparateChildren(this);
                
                ComposableParent = null;

                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            catch (Exception e)
            {
                return new ActionResult<string>(false, e.Message);
            }
        }

        public void ConditionUpdate();
    }
}
