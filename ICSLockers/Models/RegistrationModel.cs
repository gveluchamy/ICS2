using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSLockers.Models
{
    public class RegistrationModel:ApplicationUser
    {
          public string Role { get; set; }
       
    }
}
