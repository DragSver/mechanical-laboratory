using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment
{
    public interface IInfo
    {
        public EquipmentData CurrentEquipmentData { get; }
        
        public void CallInfo();
    }
}
