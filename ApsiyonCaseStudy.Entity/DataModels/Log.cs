using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApsiyonCaseStudy.Entity.DataModels
{
    [Table("tblLog", Schema = "dbo")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}
