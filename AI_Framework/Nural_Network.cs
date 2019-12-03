using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AI_Framework
{
    class Nural_Network
    {
        private Layer input, output;
        public Nural_Network(int[] structure)
        {
            input = new Layer(structure, 0);
            output = input.Get_Output();
        }
        //public float[] Get_Output() => output.
    }
}
