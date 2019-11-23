using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("AspNetRoles")]
    public class DaoRole : IdentityRole<int>
    {
    }
}
