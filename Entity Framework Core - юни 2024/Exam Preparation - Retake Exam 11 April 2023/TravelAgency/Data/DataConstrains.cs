using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public static class DataConstrains
    {
        //Customer
        public const byte CustomerFullNameMinLenght = 4;
        public const byte CustomerFullNameMaxLenght = 60;

        public const byte CustomerEmilMinLenght = 6;
        public const byte CustomerImeilMaxLenght = 50;


        //Guide
        public const byte GuideFullNameMinLenght = 4;
        public const byte GuideFullNameMaxLenght = 60;

        //TourPackage
        public const byte TourPackageNameMinLenght = 2;
        public const byte TourPackageNameMaxLenght = 40;

        public const byte DescriptionMaxLenght = 200;



    }
}
