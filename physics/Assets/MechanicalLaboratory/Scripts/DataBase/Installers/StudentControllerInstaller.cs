using MechanicalLaboratory.Scripts.DataBase.Controllers;
using Zenject;

namespace MechanicalLaboratory.Scripts.DataBase.Installers
{
    public class StudentControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<StudentController>()
                .FromNew()
                .AsSingle().NonLazy();
        }
    }
}