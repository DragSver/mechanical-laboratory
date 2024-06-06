using System;
using System.Collections.Generic;

namespace MechanicalLaboratory.Scripts.DataBase.Entities
{
    public class StudyGroup
    {
        public Guid Id;
        public string Title;
        public Teacher Creator;
        public List<Student> Students;
    }
}