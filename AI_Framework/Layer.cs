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
        public Layer (int[] structure, int layer)
        {
            if (layer != structure.Length - 1) child = new Layer(structure, layer + 1);
            else child = null;
            this.layer = new Node[structure[layer] - 1];
            for (int i = 0; i < structure[layer]; i++)
            {
                this.layer[i] = new Node(layer == 0? 1 : structure[layer - 1], layer == structure.Length - 1? 1 : structure[layer], this);
            }
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
                child.Add(value, false);
            }
            else for (int i = 0; i < value.Length; i++) layer[i].Add(value[i]);
        }
        public void Set_Inputs(float[] values)
        {
            for (int i = 0; i < values.Length; i++) layer[i].Pass(values[i]);
        }
    }
}
