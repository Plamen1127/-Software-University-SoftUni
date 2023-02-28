using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>(); ;
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }
        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity== Count)
            {
                return "No more space in the storage room.";
            }
            else
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
        }

        public int RemoveShoes(string material)
        {
            if (Shoes.Count==0)
            {
                return 0;
            }
            else
            {
                int qtyRemoved = 0;

                for (int i = 0; i < Shoes.Count; i++)
                {
                    if (Shoes[i].Material== material)
                    {
                        qtyRemoved++;
                        Shoes.RemoveAt(i);
                        i--;
                    }
                    
                }
                return qtyRemoved;
            }
        }

        public List<Shoe> GetShoesByType(string type)
        {
            type = type.ToLower();

            List<Shoe> byType = new List<Shoe>();

            foreach (var shoe in Shoes)
            {
                if (shoe.Type== type)
                {
                    byType.Add(shoe);
                }
            }

            return byType;
        }

        public Shoe GetShoeBySize( double size)
        {
            Shoe firstShoeBysaze = Shoes.FirstOrDefault(s => s.Size == size);
            if (firstShoeBysaze==null)
            {
                return null;
            }
            else
            {
                return firstShoeBysaze;
            }
        }

        public string StockList( double size, string type)
        {
            List<Shoe> stockListBySizeAndType = new List<Shoe>();

            StringBuilder sb = new StringBuilder();

            foreach (var shoe in Shoes)
            {
                if (shoe.Size==size && shoe.Type==type)
                {
                    stockListBySizeAndType.Add(shoe);
                }
            }

            if (stockListBySizeAndType.Count==0)
            {
                return "No matches found!";
            }
            else
            {
               sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var shoe in stockListBySizeAndType)
                {
                    sb.AppendLine(shoe.ToString());
                }

                return sb.ToString().Trim();
            }
        }
    }
}
