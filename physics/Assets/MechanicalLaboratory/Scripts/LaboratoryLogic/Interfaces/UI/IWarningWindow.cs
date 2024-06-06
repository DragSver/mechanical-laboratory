namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI
{
    public interface IWarningWindow
    {
        public void CallWarning(string warningText);
        public bool IsActiveAndEnabled();
        public void SetActive(bool active);
    }
}
