using System;
using System.Collections.Generic;
using MechanicalLaboratory.Scripts.StepHandler.Data;

namespace MechanicalLaboratory.Scripts.DataBase.Entities
{
    public class Report
    {
        public Guid Id;
        public Student Creator;
        public Laboratory Laboratory;
        public DateTime CreatedTime;
        public TimeSpan ExecutionTime;
        public List<Step> CurrentSteps;
    }
}