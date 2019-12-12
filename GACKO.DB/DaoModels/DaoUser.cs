using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    /// <summary>
    /// AspNetUsers Table Data Access Object 
    /// </summary>
    [Table("AspNetUsers")]
    public class DaoUser : IdentityUser<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
