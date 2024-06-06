namespace MechanicalLaboratory.Scripts.StepHandler.Interfaces
{
    public interface IStepController
    {
        public void CompleteStep();
        public void SkipStep();
        public void CheckStepComplete();
    }
}