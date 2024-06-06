using System;
using MechanicalLaboratory.Scripts.StepHandler.Enum;

namespace MechanicalLaboratory.Scripts.StepHandler.Data
{
    [Serializable]
    public struct Step
    {
        public string StepDescription;
        
        public InputData InputData;
        public StepExecutionCondition ExecutionCondition;
        
        public CompletionStatus CompletionStatus;
    }
}