using System.ComponentModel.DataAnnotations;

namespace shop_MahdiTaremi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
       // [Required]
        public string? FirstName { get; set; }
 //[StringLength(50)]
 //[Required]
        public string LastName { get; set; }
// [StringLength(50)]
// [Required]
        public int Password { get; set; }
//[Required]
        public Boolean Gender { get; set; }
        public string? Description { get; set; }
        // DateTime DateCreate { get; set; }
        // DataType(DataType.Date)]   
        public DateTime Date { get; set; }
        //public string? Pic_1 { get; set;}

        }
}
