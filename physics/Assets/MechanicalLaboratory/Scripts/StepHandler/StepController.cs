using System.Collections.Generic;
using MechanicalLaboratory.Scripts.StepHandler.Data;
using MechanicalLaboratory.Scripts.StepHandler.Enum;
using MechanicalLaboratory.Scripts.StepHandler.Interfaces;
using MechanicalLaboratory.Scripts.StepHandler.Interfaces.UI;
using Zenject;

namespace MechanicalLaboratory.Scripts.StepHandler
{
    public class StepController : IStepController
    {
        private readonly List<Step> _currentExecutionSteps;

        private Step _currentStep
        {
            get => _currentExecutionSteps[_currentStepNumber];
            set => _currentExecutionSteps[_currentStepNumber] = value;
        } 
        private int _currentStepNumber;
        
        [Inject] private readonly IStepWindow _stepWindow;

        public StepController(List<Step> currentExecutionSteps, IStepWindow stepWindow)
        {
            _currentExecutionSteps = currentExecutionSteps;
            _stepWindow = stepWindow;
        }

        private void Start()
        {
            NextStep();
        }
        public void CompleteStep()
        {
            if (_currentStep.CompletionStatus != CompletionStatus.AwaitingCompletion)
                return;
            
            var newStep = _currentStep;

            if (_currentStep.InputData.Title != "")
            {
                var newData = _currentStep.InputData;
                newData.Value = _stepWindow.GetInputValue();
                newStep.InputData = newData;
            }

            newStep.CompletionStatus = CompletionStatus.Complete;
            
            _currentStep = newStep;
            
            NextStep();
        }
        public void SkipStep()
        {
            var newStep = _currentStep;
            
            if (_currentStep.InputData.Title != "")
            {
                var newData = _currentStep.InputData;
                newData.Value = _stepWindow.GetInputValue();
                newStep.InputData = newData;
            }
            
            newStep.CompletionStatus = CompletionStatus.Skipped;
            
            _currentStep = newStep;
            
            NextStep();
        }
        private void NextStep()
        {
            while (_currentExecutionSteps[_currentStepNumber].CompletionStatus is CompletionStatus.Complete 
                                                                                or CompletionStatus.Skipped  
                   && _currentStepNumber < _currentExecutionSteps.Count-1)
            {
                _currentStepNumber++;
            }

            _currentStep = _currentExecutionSteps[_currentStepNumber];
            if (_currentStep.CompletionStatus == CompletionStatus.NotStarted)
            {
                var step = _currentStep;
                step.CompletionStatus = CompletionStatus.InProcess;
                _currentStep = step;
            }
            
            _stepWindow.CallStep(_currentStep);
            CheckStepComplete();
        }

        public void CheckStepComplete()
        {
            var stepComplete = true;

            if (_currentStep.ExecutionCondition.ConditionSuccessfulCompletion != "")
                if (!_currentStep.ExecutionCondition.Complete)
                    stepComplete = false;
            
            if (_stepWindow.GetInputValue() == "")
                stepComplete = false;

            if (stepComplete)
            {
                var newStep = _currentStep;
                newStep.CompletionStatus = CompletionStatus.AwaitingCompletion;
                _currentStep = newStep;
                
                _stepWindow.StepAwaitingCompletion();
            }
        }
    }
}