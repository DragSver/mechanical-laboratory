using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;

namespace MechanicalLaboratory.Scripts.DataBase.Interfaces
{
    public interface IUserController<T> : IDBController<T>
    {
        public static byte[] GenerateSalt(int size = 16)
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[size];
            rng.GetBytes(salt);
            return salt;
        }
        public static byte[] DoubleHashPassword(string password, byte[] salt)
        {
            var sha256 = SHA256.Create();

            var bytePassword = Encoding.UTF8.GetBytes(password);
            var firstHash = sha256.ComputeHash(bytePassword.Concat(salt).ToArray());
            var secondHash = sha256.ComputeHash(firstHash.Concat(salt).ToArray());
            
            return secondHash;
        }
        public static bool VerifyPassword(string inputPassword, byte[] storedSalt, byte[] passwordHash)
        {
            byte[] inputHash = DoubleHashPassword(inputPassword, storedSalt);
            return inputHash.SequenceEqual(passwordHash);
        }

        public Task<ActionResult<T>> GetFromMail(string mail);
    }
}