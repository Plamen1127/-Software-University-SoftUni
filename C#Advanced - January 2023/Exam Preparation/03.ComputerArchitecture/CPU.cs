using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        public CPU(string brand, int corse, double frequency)
        {
            Brand = brand;
            Cores = corse;
            Frequency = frequency;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} CPU:");
            sb.AppendLine($"Cores: {Cores}");
            sb.AppendLine($"Frequency: {Frequency:F1} GHz");
            return sb.ToString().Trim();
        }
    }
}
