using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarisTutakli.WebApi.Models.Concrete
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public  DateTime PublishDate { get; set; }


    }
}
