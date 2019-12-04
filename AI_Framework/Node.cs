using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Framework
{
    class Node
    {
        private int parents, children, received;
        double[] weights;
        private double sum, bias;
        private Layer layer;
        private Random random;
        public Node(int parents, int children, Layer layer)
        {
            this.parents = parents;
            this.children = children;
            this.layer = layer;
            random = new Random();
            bias = random.NextDouble() * 10.0 - 5.0;
            if (children != -1)
            {
                weights = new double[children];
                for (int i = 0; i < children; i++) weights[i] = random.NextDouble() * 10.0 - 5.0;
            }
            Console.WriteLine("Node generated with a bias of {0}, weights of [{1}] {2} parnts and {3} children", bias, string.Join(", ", weights), parents, children);
        }
        public void Add(double value)
        {
            Console.WriteLine("{0} added to {1}", value, sum);
            sum += value;
            received++;
            if (received == parents) Pass(sum);
        }
        public void Pass(double sum)
        {
            Console.WriteLine("{0} mapped to {1}", sum, 1.0 / (1.0 + Math.Exp(bias - sum)));
            this.sum = 1.0 / (1.0 + Math.Exp(bias - sum));
            double[] weighted_sums = new double[children];
            for (int i = 0; i < children; i++) weighted_sums[i] = sum * weights[i];
            layer.Add(weighted_sums, true);
        }
        public double Get_Sum() => sum;
        public void Reset()
        {
            received = 0;
            sum = 0;
        }
    }
}
