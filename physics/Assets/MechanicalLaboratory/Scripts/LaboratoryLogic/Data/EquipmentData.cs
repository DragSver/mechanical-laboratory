using System;
using System.Collections.Generic;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Data
{
    [Serializable]
    public struct EquipmentData
    {
        public string Name;
        public string Description;
        public List<Measurement> Measurements;
    }
}