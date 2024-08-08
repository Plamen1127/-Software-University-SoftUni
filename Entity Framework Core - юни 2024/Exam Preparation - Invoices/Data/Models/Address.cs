﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    using static DataConstrains;
    public class Address
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(AddressMaxLenght)]
        public string StreetName  { get; set; } = null!;


        [Required]
        public int StreetNumber  { get; set; }


        [Required]
        public string PostCode { get; set; } = null!;


        [Required]
        [MaxLength(CityNameMaxLenght)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(CountryMaxLenght)]
        public string Country { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId  { get; set; }

        [Required]
        public virtual Client Client { get; set; } = null!;


    }
}
