using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{/// <summary>
    /// AspNetRoles Table Data Access Object 
    /// </summary>
    [Table("AspNetRoles")]
    public class DaoRole : IdentityRole<int>
    {
    }
}
