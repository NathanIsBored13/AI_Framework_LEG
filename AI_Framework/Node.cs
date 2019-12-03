using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Framework
{
    class Node
    {
        private int parents, children, received;
        private double[] weights;
        private double sum, weight;
        private Layer layer;
        private Random random;
        public Node(int parents, int children, Layer layer)
        {
            this.parents = parents;
            this.children = children;
            this.layer = layer;
            if (children != -1)
            {
                weights = new double[children];
                for (int i = 0; i < children; i++) weights[i] = random.NextDouble();
            }
        }
        public void Add(double value)
        {
            sum += value;
            received++;
            if (received == parents) Pass(sum);
        }
        public void Pass(double sum)
        {
            sum = 1.0 / (1.0 + Math.Exp(-sum));
            double[] weighted_sums = new double[children];
            for (int i = 0; i < children; i++) weighted_sums[i] = sum * weights[i] * weight;
            layer.Add(weighted_sums, true);
        }
    }
}
