using System;
using System.Data;
using System.Threading.Tasks;
using MechanicalLaboratory.Scripts.DataBase.Entities;
using MechanicalLaboratory.Scripts.DataBase.Interfaces;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.DataBase.Controllers
{
    public class TeacherController : IUserController<Teacher>
    {
        [Inject] private IDataAccess _dataAccess;
        
        
        public async Task<ActionResult<string>> Add(Teacher teacher)
        {
            var id = Guid.NewGuid();
            var blobId = id.ToByteArray();
            
            var salt = IUserController<Teacher>.GenerateSalt();
            var hashPassword = IUserController<Teacher>.DoubleHashPassword(teacher.Password, salt);
            
            var insertSql = "INSERT INTO Teachers (Id, Name, Surname, Mail, Password, Salt) " +
                            $"VALUES (@id, '{teacher.Name}', '{teacher.Surname}', '{teacher.Mail}', @password, @salt);";
            var command = await _dataAccess.CreateCommand(insertSql);
            
            try
            {
                command.Parameters.AddWithValue("@id", blobId);
                command.Parameters.AddWithValue("@password", hashPassword);
                command.Parameters.AddWithValue("@salt", salt);
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
        
        public async Task<ActionResult<Teacher>> Get(Guid id)
        {
            var blobGuid = id.ToByteArray();
            
            var selectSql = $"SELECT Name, Surname, Mail FROM Teachers WHERE Id = {blobGuid} LIMIT 1";
            var command = await _dataAccess.CreateCommand(selectSql);
            
            try
            {
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var mail = (string)reader["Mail"];
                    var teacher = new Teacher {
                        Id = id,
                        Name = name,
                        Surname = surname,
                        Mail = mail
                    };
                    await command.Transaction.CommitAsync();
                    return new ActionResult<Teacher>(true, teacher);
                }
                await command.Transaction.CommitAsync();
                return new ActionResult<Teacher>(false, null);
            }
            catch (Exception e)
            {
                await command.Transaction.RollbackAsync();
                
                Debug.Log(e);
                return new ActionResult<Teacher>(false, null);
            }
        }
        public async Task<ActionResult<Teacher>> GetFromMail(string mail)
        {
            var selectSql = $"SELECT Id, Name, Surname FROM Teachers WHERE Mail = '{mail}' LIMIT 1";
            var command = await _dataAccess.CreateCommand(selectSql);
            
            try
            {
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                { 
                    var id = new Guid((byte[])reader["Id"]);
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var teacher = new Teacher {
                        Id = id,
                        Name = name,
                        Surname = surname,
                        Mail = mail
                    };
                    await command.Transaction.CommitAsync();
                    return new ActionResult<Teacher>(true, teacher);
                }
                await command.Transaction.CommitAsync();
                return new ActionResult<Teacher>(false, null);
            }
            catch (Exception e)
            {
                await command.Transaction.RollbackAsync();
                
                Debug.Log(e);
                return new ActionResult<Teacher>(false, null);
            }
        }
    }
}