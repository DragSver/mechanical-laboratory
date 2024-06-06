namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment
{
    public interface IInteractable : IOutline, IInfo
    {
        public void OnMouseEnter();
        public void OnMouseExit();
    }
}
