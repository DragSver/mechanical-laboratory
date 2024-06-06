using System;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Data
{
    [Serializable]
    public struct Measurement
    {
        public string Designation;
        public string Name;
        public string Measure;
        public float Value;
    }
}