using ICSLockers.Models;

namespace ICSLockers.Helpers
{
    public class AccountHelper
    {
        public static string CreatePassword(RegistrationModel user)
        {
            string password = string.Empty;

            if (user.FirstName == null || user.LastName == null || user.SSN == 0)
            {
                return password;
            }
            string SSN = (user.SSN % 100).ToString();
            password = string.Concat(user.FirstName[..1], user.LastName[..1], SSN);

            password = password.Length > 4 ? string.Empty : password;

            return password;
        }

    }
}
