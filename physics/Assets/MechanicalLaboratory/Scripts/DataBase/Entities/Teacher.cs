using System.Collections.Generic;

namespace MechanicalLaboratory.Scripts.DataBase.Entities
{
    public class Teacher : LaboratoryUser
    {
        public List<Laboratory> Laboratories;
    }
}