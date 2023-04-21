using ICSLockers.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace ICSLockers.Helpers
{
    public class AccountHelper
    {
        public static string CreatePassword(ApplicationUser user)
        {
            try
            {
                string password = string.Empty;

                if (user.FirstName == null || user.LastName == null || user.DateOfBirth == null)
                {
                    return password;
                }
                string DateOfBirth = (user.DateOfBirth).ToString();
                DateTime date = DateTime.ParseExact(DateOfBirth, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string year = date.ToString("yyyy");
                password = string.Concat(user.FirstName[..1], user.LastName[..1], year);

                password = password.Length > 6 ? string.Empty : password;
                return password;

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);                
            }
            return string.Empty;
        }

    }
}
