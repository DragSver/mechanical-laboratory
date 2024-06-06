using UnityEngine;
using UnityEngine.UI;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow
{
    public class InformationWindowThread : LaboratoryLogic.UI.Windows.InformationWindow.InformationWindow
    {
        [SerializeField] private Slider _sliderLength;
        [SerializeField] private Slider _sliderTilt;
        
        public float MinScale => 0.005f;
        public float MaxScale => 0.13f;
        public float MinTilt => 0f;
        public float MaxTilt => 90f;

        protected override void Awake()
        {
            base.Awake();
            InitSliders();
        }
        
        private void InitSliders()
        {
            _sliderLength.minValue = MinScale;
            _sliderLength.maxValue = MaxScale;
            _sliderTilt.minValue = MinTilt;
            _sliderTilt.maxValue = MaxTilt;
        }

        public void UpdateLengthSlider(float scaleY)
        {
            _sliderLength.value = scaleY;
        }
        public void UpdateTiltSlider(float tilt)
        {
            _sliderTilt.value = tilt;
        }
    }
}