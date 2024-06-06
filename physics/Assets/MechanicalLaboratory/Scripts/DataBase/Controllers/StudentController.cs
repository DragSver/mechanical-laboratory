using System;
using System.Threading.Tasks;
using MechanicalLaboratory.Scripts.DataBase.Entities;
using MechanicalLaboratory.Scripts.DataBase.Interfaces;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.DataBase.Controllers
{
    public class StudentController : IUserController<Student>
    {
        [Inject] private IDataAccess _dataAccess;
        
        
        public async Task<ActionResult<string>> Add(Student student)
        {
            var id = Guid.NewGuid();
            var blobId = id.ToByteArray();
            
            var salt = IUserController<Student>.GenerateSalt();
            var hashPassword = IUserController<Student>.DoubleHashPassword(student.Password, salt);
            
            var insertSql = "INSERT INTO Students (Id, Name, Surname, Mail, Password, Salt) " +
                            $"VALUES ({blobId}, {student.Name}, {student.Surname}, {student.Mail}, {hashPassword}, {salt});";
            var command = await _dataAccess.CreateCommand(insertSql);
            
            try
            {
                await command.ExecuteNonQueryAsync();
                await command.Transaction?.CommitAsync()!;

                return new ActionResult<string>(true, id.ToString());
            }
            catch (Exception e)
            {
                await command.Transaction?.RollbackAsync()!;
                
                Debug.Log(e);
                return new ActionResult<string>(false, e.Message);
            }
        }
        
        public async Task<ActionResult<Student>> Get(Guid id)
        {
            var blobGuid = id.ToByteArray();
            
            var selectSql = $"SELECT Name, Surname, Mail FROM Students WHERE Id = {blobGuid} LIMIT 1";
            var command = await _dataAccess.CreateCommand(selectSql);
            
            try
            {
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var mail = (string)reader["Mail"];
                    var student = new Student {
                        Id = id,
                        Name = name,
                        Surname = surname,
                        Mail = mail
                    };
                    await command.Transaction.CommitAsync();
                    return new ActionResult<Student>(true, student);
                }
                await command.Transaction.CommitAsync();
                return new ActionResult<Student>(false, null);
            }
            catch (Exception e)
            {
                await command.Transaction.RollbackAsync();
                
                Debug.Log(e);
                return new ActionResult<Student>(false, null);
            }
        }
        public async Task<ActionResult<Student>> GetFromMail(string mail)
        {
            var selectSql = $"SELECT Id, Name, Surname FROM Students WHERE Mail = {mail} LIMIT 1";
            var command = await _dataAccess.CreateCommand(selectSql);
            
            try
            {
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                { 
                    var id = new Guid((byte[])reader["Id"]);
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var student = new Student {
                        Id = id,
                        Name = name,
                        Surname = surname,
                        Mail = mail
                    };
                    await command.Transaction.CommitAsync();
                    return new ActionResult<Student>(true, student);
                }
                await command.Transaction.CommitAsync();
                return new ActionResult<Student>(false, null);
            }
            catch (Exception e)
            {
                await command.Transaction.RollbackAsync();
                
                Debug.Log(e);
                return new ActionResult<Student>(false, null);
            }
        }
    }
}