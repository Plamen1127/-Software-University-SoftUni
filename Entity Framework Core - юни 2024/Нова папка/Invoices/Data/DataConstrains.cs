using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data
{
    public static class DataConstrains
    {
        //roduct
        public const byte ProductNameMinLenght = 9;
        public const byte ProductNameMaxLenght = 30;

        public const string ProductPriceMin = "5.00";
        public const string ProductPriceMax = "1000.00";

        //Adress

        public const byte AddressMinLenght = 10;
        public const byte AddressMaxLenght = 20;

        public const byte CityMinLenght = 5;
        public const byte CityNameMaxLenght = 15;

        public const byte CountryMinLenght = 5;
        public const byte CountryMaxLenght = 15;

        //Invoice

        public const int NumberMinLenght = 1_000_000_000;
        public const int NumberMaxLenght = 1_500_000_000;
        public const int CurenciTypeMin = 0;
        public const int CurenciTypeMax = 2;


        //Client
        public const byte ClientNameMinLenght = 10;
        public const byte ClientNameMaxLenght = 25;

        public const byte NumberVatMinLenght = 10;
        public const byte NumberVatMaxLenght =15;

    }
}
