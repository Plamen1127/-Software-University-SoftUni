using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add( CPU cpu)
        {
            if (Multiprocessor.Count<Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU removeCPU = Multiprocessor.FirstOrDefault(m => m.Brand == brand);
            if (removeCPU != null)
            {
                Multiprocessor.Remove(removeCPU);
                return true;
            }
            else
            {
                return false;
            }  
        }

        public CPU MostPowerful()
        {
            CPU mostPawerfulCPO = Multiprocessor[0];

            foreach (var cpu in Multiprocessor)
            {
                if (cpu.Frequency> mostPawerfulCPO.Frequency)
                {
                    mostPawerfulCPO = cpu;
                }
            }

            return mostPawerfulCPO;
        }

        public CPU GetCPU(string brand)
        { 
           CPU getCpu =  Multiprocessor.FirstOrDefault(c => c.Brand == brand);

            return getCpu;

        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }

            return result.ToString().Trim();
        }

    }
}
