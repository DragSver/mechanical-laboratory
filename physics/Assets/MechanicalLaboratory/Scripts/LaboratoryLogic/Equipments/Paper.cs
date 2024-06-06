using System.Collections.Generic;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Paper : Pickable, IComposableParent
    {
        public List<IComposableChild> ComposableChild { get; set; } = new();
        
        
        public void SetUIFactory(UIController uiController)
        {
            if (_uiController is null)
                _uiController = uiController;
        }
    }
}
