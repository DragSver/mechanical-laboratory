using MechanicalLaboratory.Scripts.DataBase.Controllers;
using MechanicalLaboratory.Scripts.LaboratoryProfile.Controllers;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryProfile.Installers
{
    public class RegistrationControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TeacherController>().FromInstance(ProjectContext.Instance.Container.Resolve<TeacherController>()).AsSingle();
            Container.Bind<StudentController>().FromInstance(ProjectContext.Instance.Container.Resolve<StudentController>()).AsSingle();
            
            Container.Bind<RegistrationController>().FromNew().AsSingle();
        }
    }
}