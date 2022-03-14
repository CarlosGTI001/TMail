using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TMail.Models
{
    public class email
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "De:")]
        public string de { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Para:")]
        public string para { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public string asunto { get; set; }
        public string cuerpo { get; set; }
    }
}