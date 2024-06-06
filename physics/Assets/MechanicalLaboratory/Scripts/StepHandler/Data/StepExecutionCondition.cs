using System;

namespace MechanicalLaboratory.Scripts.StepHandler.Data
{
    [Serializable]
    public struct StepExecutionCondition
    {
        public bool Complete;
        public string ConditionSuccessfulCompletion;
    }
}