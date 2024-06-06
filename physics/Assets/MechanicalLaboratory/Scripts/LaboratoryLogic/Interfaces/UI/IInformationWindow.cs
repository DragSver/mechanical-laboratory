using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI
{
    public interface IInformationWindow
    {
        public void CallInfo(EquipmentData equipment);
        public void ClearInfo();

        public bool IsActiveAndEnabled();
        public void SetActive(bool active);
    }
}
