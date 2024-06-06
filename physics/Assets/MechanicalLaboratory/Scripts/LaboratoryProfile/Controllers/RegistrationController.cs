using System.Threading.Tasks;
using MechanicalLaboratory.Scripts.DataBase.Controllers;
using MechanicalLaboratory.Scripts.DataBase.Entities;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryProfile.Enums;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryProfile.Controllers
{
    public class RegistrationController
    {
        [Inject] private TeacherController _teacherController;
        [Inject] private StudentController _studentController;

        public async Task<ActionResult<string>> Registration(LaboratoryUser laboratoryUser, string secondPassword, Role role)
        {
            if (laboratoryUser.Password != secondPassword)
                return new ActionResult<string>(false, "Введенные пароли отличаются.");
            if (role is Role.Student)
            {
                var actionResult = await _studentController.GetFromMail(laboratoryUser.Mail);
                if (actionResult.Message != null)
                    return new ActionResult<string>(false, "Учащийся с такой почтой уже зарегистрирован.");
                var student = new Student()
                {
                    Name = laboratoryUser.Name,
                    Surname = laboratoryUser.Surname,
                    Mail = laboratoryUser.Mail,
                    Password = laboratoryUser.Password
                };
                return await _studentController.Add(student);
            }
            else if (role is Role.Teacher)
            {
                var actionResult = await _teacherController.GetFromMail(laboratoryUser.Mail);
                if (actionResult.Message != null)
                    return new ActionResult<string>(false, "Преподаватель с такой почтой уже зарегистрирован.");
                var teacher = new Teacher()
                {
                    Name = laboratoryUser.Name,
                    Surname = laboratoryUser.Surname,
                    Mail = laboratoryUser.Mail,
                    Password = laboratoryUser.Password
                };
                await _teacherController.Add(teacher);
                return new ActionResult<string>(true, "");
            }
            return new ActionResult<string>(false, "Неизвестная ошибка");
        }
    }
}