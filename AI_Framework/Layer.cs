using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AI_Framework
{
    class Layer
    {
        private Layer child;
        private Node[] layer;
        public int depth;
        public Layer (int[] structure, int layer)
        {
            depth = layer;
            if (layer != structure.Length - 1) child = new Layer(structure, layer + 1);
            else child = null;
            this.layer = new Node[structure[layer]];
            for (int i = 0; i < structure[layer]; i++)
            {
                this.layer[i] = new Node(layer == 0? 1 : structure[layer - 1], layer == structure.Length - 1? 1 : structure[layer + 1], this);
            }
            Console.WriteLine("layer generated with {0} nodes", this.layer.Length);
        }
        public Layer Get_Output()
        {
            Layer buffer;
            if (child == null) buffer = this;
            else buffer = child.Get_Output();
            return buffer;
        }
        public void Add(double[] value, bool pass)
        {
            if (pass)
            {
                Console.WriteLine("passeing {0} values from {1} to {2}", value.Length, depth, depth + 1);
                if (child != null) child.Add(value, false);
            }
            else
            {
                for (int i = 0; i < value.Length; i++) layer[i].Add(value[i]);
            }
        }
        public void Set_Inputs(float[] values)
        {
            for (int i = 0; i < values.Length; i++) layer[i].Pass(values[i]);
        }
        public double[] Get_Node_Values()
        {
            double[] buffer = new double[layer.Length];
            for (int i = 0; i < layer.Length; i++)
            {
                buffer[i] = layer[i].Get_Sum();
            }
            return buffer;
        }
        public void Reset()
        {
            foreach (Node node in layer) node.Reset();
            if (child != null) child.Reset();
        }
    }
}
