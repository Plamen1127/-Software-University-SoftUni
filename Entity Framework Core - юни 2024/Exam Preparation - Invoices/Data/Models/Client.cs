using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    using static DataConstrains;
    public class Client
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(ClientNameMaxLenght)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(NumberVatMaxLenght)]
        public string NumberVat { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public  virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        public virtual ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
