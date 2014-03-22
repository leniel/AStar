using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AStar
{
    class Path<Node> : IEnumerable<Path<Node>>
    {
        public Node LastStep { get; private set; }
        
        public Path<Node> PreviousSteps { get; private set; }
        
        public double TotalCost { get; private set; }
        
        private Path(Node lastStep, Path<Node> previousSteps, double totalCost)
        {
            LastStep = lastStep;
            
            PreviousSteps = previousSteps;
            
            TotalCost = totalCost;
        }

        public Path(Node start) : this(start, null, 0) { }
        
        public Path<Node> AddStep(Node step, double stepCost)
        {
            return new Path<Node>(step, this, TotalCost + stepCost);
        }
        
        public IEnumerator<Path<Node>> GetEnumerator()
        {
            for(Path<Node> p = this; p != null; p = p.PreviousSteps)
                yield return p;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
