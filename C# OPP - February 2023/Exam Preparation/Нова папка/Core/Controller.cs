using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        private string[] delicacyType = new string[] { typeof(Gingerbread).Name, typeof(Stolen).Name };
        private string[] cocktailType = new string[] { typeof(Hibernation).Name, typeof(MulledWine).Name };
        private string[] coctailSizeType = new string[] { "Small", "Middle", "Large" };

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (!delicacyType.Contains(delicacyTypeName))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (delicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (!cocktailType.Contains(cocktailTypeName))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if (!coctailSizeType.Contains(size))
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail = booth.CocktailMenu.Models
                .FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (cocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                 .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                 .OrderBy(b => b.Capacity)
                 .ThenByDescending(b => b.BoothId)
                 .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }


            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInfo = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int countOrderedPieces = int.Parse(orderInfo[2]);
            string size = string.Empty;

            if (orderInfo.Length == 4)
            {
                size = orderInfo[3];
            }


            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (!cocktailType.Contains(itemTypeName) && !delicacyType.Contains(itemTypeName))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (cocktailType.Contains(itemTypeName))
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOrderedPieces, itemName);
            }
            else
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * countOrderedPieces);


                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOrderedPieces, itemName);

            }

        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.Append($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd();

        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            return booth.ToString();
        }




    }
}
