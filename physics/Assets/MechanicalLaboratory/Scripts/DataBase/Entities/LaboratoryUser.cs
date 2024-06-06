using System;
using System.Collections.Generic;

namespace MechanicalLaboratory.Scripts.DataBase.Entities
{
    public class LaboratoryUser
    {
        public Guid Id;
        public string Name;
        public string Surname;
        public string Mail;
        public string Password;
        public List<StudyGroup> StudyGroups;
    }
}