using MechanicalLaboratory.Scripts.DataBase.Entities;
using MechanicalLaboratory.Scripts.LaboratoryProfile.Controllers;
using MechanicalLaboratory.Scripts.LaboratoryProfile.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryProfile.UI
{
    public class RegistrationWindow : MonoBehaviour
    {
        [Inject] private RegistrationController _registrationController;
        
        [SerializeField] private TMP_InputField _inputName;
        [SerializeField] private TMP_InputField _inputSurname;
        [SerializeField] private TMP_InputField _inputMail;
        [SerializeField] private TMP_InputField _inputPassword;
        [SerializeField] private TMP_InputField _inputSecondPassword;
        [SerializeField] private Button _studentButton;
        [SerializeField] private Button _teacherButton;
        [SerializeField] private TextMeshProUGUI _warning;
        
        private Role _role = Role.Teacher;
        
        
        public void SetStudentRole()
        {
            _role = Role.Student;
            _studentButton.image.color = Color.blue;
            _studentButton.enabled = false;
            _teacherButton.enabled = true;
            _teacherButton.image.color = Color.clear;
        }
        public void SetTeacherRole()
        {
            _role = Role.Teacher;
            _teacherButton.image.color = Color.blue;
            _teacherButton.enabled = false;
            _studentButton.enabled = true;
            _studentButton.image.color = Color.clear;
        }

        public void CallAuthorisation()
        {
            
        }

        public async void Registration()
        {
            if (_inputName.text == "" ||
                _inputSurname.text == "" ||
                _inputMail.text == "" ||
                _inputPassword.text == "")
            {
                CallWarning("Заполните все поля.");
                return;
            }
            var laboratoryUser = new LaboratoryUser()
            {
                Name = _inputName.text,
                Surname = _inputSurname.text,
                Mail = _inputMail.text,
                Password = _inputPassword.text
            };
            var actionResult = await _registrationController.Registration(laboratoryUser, _inputSecondPassword.text, _role);
            if (!actionResult.Success)
            {
                CallWarning(actionResult.Message);
            }
        }
        private void CallWarning(string warningText)
        {
            _warning.SetText(warningText);
        }
        public void ClearWarning()
        {
            _warning.SetText("");
        }
    }
}
