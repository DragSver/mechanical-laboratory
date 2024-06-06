using MechanicalLaboratory.Scripts.LaboratoryLogic.Enums;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings", order = 1)]
    public class LaboratorySettings : ScriptableObject
    { 
        public Language Language;
        public ScreenResolution ScreenResolution;
        public GraphicsLevel GraphicsLevel;
        public float SoundVolume;
    }
}
