using System.Globalization;
using TMPro;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI
{
    public class DynamometerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textValue;
        
        
        public void CallValue(float fMeasurementValue)
        {
            _textValue.text = fMeasurementValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}