using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MechanicalLaboratory.Scripts.StepHandler.Data;

namespace MechanicalLaboratory.Scripts.DataBase.Entities
{
    public class Laboratory
    {
        public Guid Id;
        public string Title;
        public string Description;
        public List<Step> Steps;
        [CanBeNull] public Teacher Creator;
    }
}