using System.ComponentModel.DataAnnotations;

namespace shop_MahdiTaremi.Models
{
    public class Basket
    {
        [Key] 
        public int Id { get; set; }
        public int BasketId { get; set; }
    }
}
