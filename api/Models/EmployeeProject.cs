using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
