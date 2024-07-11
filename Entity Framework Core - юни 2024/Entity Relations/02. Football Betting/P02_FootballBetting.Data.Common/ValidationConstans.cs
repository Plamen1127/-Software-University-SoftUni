using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Common
{
    public static class ValidationConstans
    {
        //Team
        public const int TeamNameMaxLength = 50;
        public const int TeamLogoUrlMaxLength = 2045;
        public const int TeamInitialsMaxLength = 4;

        //Color
        public const int ColorNameMaxLength = 12;

        //Town
        public const int TownNameMaxLength = 60;

        //Country
        public const int CountryNameMaxLength = 60;

        //Player
        public const int PlayerNameMaxLength = 60;

        //Posicion
        public const int PosicionNameMaxLength = 60;

        //Game
        public const int GameResultMaxLength = 10;

        //User
        public const int UserNameMaxLength = 36;
        public const int UserFullNameMaxLength = 255;
        public const int PasswordMaxLength = 255;
        public const int EmailMaxLength = 20;


    }
}
