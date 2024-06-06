using MechanicalLaboratory.Scripts.StepHandler.Data;
using TMPro;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.StepHandler.UI
{
    public class InputDataField : MonoBehaviour
    {
        public string Value => _inputField.text;
        
        [SerializeField] private StepWindow _stepWindow;
        
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TMP_InputField _inputField;
        
        public void Start()
        {
            _inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }

        public void Call(InputData inputData)
        {
            _title.SetText(inputData.Title);
            _inputField.text = "";
        }
        
        private void ValueChangeCheck()
        {
            if(_inputField.text != "")
            {
                _stepWindow.CheckStepComplete();
            }
        }
    }
}