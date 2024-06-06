using MechanicalLaboratory.Scripts.StepHandler.Data;

namespace MechanicalLaboratory.Scripts.StepHandler.Interfaces.UI
{
    public interface IStepWindow
    {
        public void CompleteStep();
        public void SkipStep();
        public void CallAllStep();
        
        public void CallStep(Step step);
        public void StepAwaitingCompletion();
        public string GetInputValue();
        
        public void CheckStepComplete();
    }
}