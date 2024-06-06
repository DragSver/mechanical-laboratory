using System.Collections.Generic;
using MechanicalLaboratory.Scripts.StepHandler.Data;
using MechanicalLaboratory.Scripts.StepHandler.Enum;
using MechanicalLaboratory.Scripts.StepHandler.Interfaces;
using MechanicalLaboratory.Scripts.StepHandler.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MechanicalLaboratory.Scripts.StepHandler.UI
{
    public class StepWindow : MonoBehaviour, IStepWindow
    {
        [Inject] private IStepController _stepController;
        
        [SerializeField] private TextMeshProUGUI _stepDescription;
        [SerializeField] private List<CompletionStatusImages> _completionStatusImages;
        [SerializeField] private Button _nextStepButton;
        [SerializeField] private InputDataField _inputDataField;
        
        
        public void CompleteStep()
        {
            _stepController.CompleteStep();
        }
        public void SkipStep()
        {
            _stepController.SkipStep();
        }
        public void CheckStepComplete()
        {
            _stepController.CheckStepComplete();
        }
        
        public void CallAllStep()
        {
            
        }
        
        public void CallStep(Step step)
        {
            Clear();
            
            _stepDescription.text = step.StepDescription;
            _completionStatusImages.Find(x => x.CompletionStatus == CompletionStatus.InProcess)?.Image.SetActive(true);
            if (step.InputData.Title != "")
            {
                _inputDataField.gameObject.SetActive(true);
                _inputDataField.Call(step.InputData);
            }
        }
        public void StepAwaitingCompletion()
        {
            SetNextButtonActive(true);
            
            _completionStatusImages.Find(x => x.CompletionStatus == CompletionStatus.InProcess)?.Image.SetActive(false);
            _completionStatusImages.Find(x => x.CompletionStatus == CompletionStatus.AwaitingCompletion)?.Image.SetActive(true);
        }
        public string GetInputValue()
        {
            return _inputDataField.Value;
        }

        
        private void Clear()
        {
            _stepDescription.text = "";
            _completionStatusImages
                .Find(x => x.gameObject.activeInHierarchy)?
                .gameObject.SetActive(false);
            SetNextButtonActive(false);
            _inputDataField.gameObject.SetActive(false);
        }

        private void SetNextButtonActive(bool active)
        {
            if (active)
            {
                
            }
            else
            {
                
            }
            
            _nextStepButton.enabled = active;
        }
    }
}