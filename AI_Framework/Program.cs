using System;

namespace AI_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] structure = new int[] { 4, 3, 3, 1 };
            Nural_Network nural_network = new Nural_Network(structure);
            nural_network.Set_Input(new double[] { 0.666, 0.69, 0.420, 0.911 });
            double[] output = nural_network.Get_Output();
            Console.WriteLine("\n[{0}]", string.Join(", ", output));
        }
    }
}
