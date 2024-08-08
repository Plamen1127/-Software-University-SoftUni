using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data
{
    public static class DataConstrains
    {
        //Boardgame
        public const byte BoardgameNameMinLenght = 10;
        public const byte BoardgameNameMaxLenght = 20;

        public const double RatingMin =1.00;
        public const double RatingMax = 10.00;

        public const int YearPublishedMin  = 2018;
        public const int YearPublishedMax = 2023;

        //Seller
        public const byte SellerNameMinLenght = 5;
        public const byte SellerNameMaxLenght = 20;

        public const byte AddressMinLenght = 2;
        public const byte AddressMaxLenght = 30;

        //Creator
        
        public const byte CreatorFirstNameMinLenght = 2;
        public const byte CreatorFirstNameMaxLenght = 7;

        public const byte CreatorLastNameMinLenght = 2;
        public const byte CreatorLastNameMaxLenght = 7;
    }
}
