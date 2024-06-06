using UnityEngine;
using UnityEngine.UI;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow
{
    public class InformationWindowTripod : LaboratoryLogic.UI.Windows.InformationWindow.InformationWindow
    {
        [SerializeField] private Slider _sliderHeightUpperCrossbar;
        [SerializeField] private Slider _sliderRotateUpperCrossbar;
        [SerializeField] private Slider _sliderHeightLowerCrossbar;
        [SerializeField] private Slider _sliderRotateLowerCrossbar;


        public void InitUpperCrossbarSliders(float minHeight, float maxHeight, float minRotate, float maxRotate)
        {
            _sliderHeightUpperCrossbar.minValue = minHeight;
            _sliderHeightUpperCrossbar.maxValue = maxHeight;
            _sliderRotateUpperCrossbar.minValue = minRotate;
            _sliderRotateUpperCrossbar.maxValue = maxRotate;
        }
        public void InitLowerCrossbarSliders(float minHeight, float maxHeight, float minRotate, float maxRotate)
        {
            _sliderHeightLowerCrossbar.minValue = minHeight;
            _sliderHeightLowerCrossbar.maxValue = maxHeight;
            _sliderRotateLowerCrossbar.minValue = minRotate;
            _sliderRotateLowerCrossbar.maxValue = maxRotate;
        }
        
        public void UpdateHeightSliderUpperCrossbar(float height) => _sliderHeightUpperCrossbar.value = height;
        public void UpdateHeightSliderLowerCrossbar(float height) => _sliderHeightLowerCrossbar.value = height;
        
        public void UpdateRotateSliderUpperCrossbar(float eulerAngles) => _sliderRotateUpperCrossbar.value = eulerAngles;
        public void UpdateRotateSliderLowerCrossbar(float eulerAngles) => _sliderRotateLowerCrossbar.value = eulerAngles;
        
    }
}