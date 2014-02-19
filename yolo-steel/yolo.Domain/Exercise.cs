using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.Domain
{
    public class Exercise
    {
        private string _name;
        private int _reps;
        private decimal _prescribedWeight;

        public Exercise(string name, int reps, decimal prescribedWeight)
        {
            _name = name;
            _reps = reps;
            _prescribedWeight = prescribedWeight;
        }
    }
}