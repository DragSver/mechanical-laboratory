using MechanicalLaboratory.Scripts.DataBase.Controllers;
using Zenject;

namespace MechanicalLaboratory.Scripts.DataBase.Installers
{
    public class TeacherControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<TeacherController>()
                .FromNew()
                .AsSingle().NonLazy();
        }
    }
}