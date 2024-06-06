using System;
using System.Collections.Generic;
using System.Reflection;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment
{
    public interface IComposableParent : IInteractable
    {
        public List<IComposableChild> ComposableChild { get; set; }
        
        public ActionResult<string> ComposedWithChild(IComposableChild composableChild)
        {
            try
            {
                ComposableChild.Add(composableChild);
                
                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            catch (Exception e)
            {
                return new ActionResult<string>(false, e.Message);
            }
        }
        
        public ActionResult<string> SeparateChildren(IComposableChild composableChild)
        {
            try
            {
                ComposableChild.Remove(composableChild);
                
                return ActionResult<string>.SuccessResult(
                    MethodBase.GetCurrentMethod()?.Name, 
                    CurrentEquipmentData.Name);
            }
            catch (Exception e)
            {
                return new ActionResult<string>(false, e.Message);
            }
        }
    }
}
