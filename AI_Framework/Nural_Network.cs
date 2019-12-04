using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AI_Framework
{
    class Nural_Network
    {
        private Layer input, output;
        public int[] structure { get; }
        public Nural_Network(int[] structure)
        {
            this.structure = structure;
            input = new Layer(structure, 0);
            output = input.Get_Output();
            Console.WriteLine("\nnetwork generated\n");
        }
        public void Set_Input(double[] values)
        {
            if (values.Length == structure[0]) input.Add(values, false);
        }
        public double[] Get_Output() => output.Get_Node_Values();
        public void Reset()
        {
            input.Reset();
        }
    }
}
