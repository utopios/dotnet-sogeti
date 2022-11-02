using Bowling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    public class Frame
    {
        private int score;
        private List<Roll> rolls;
        private bool _lastFrame;
        private IGenerator _generator;

        public Frame(bool lastFrame, IGenerator generator)        {
            LastFrame = lastFrame;
            Generator = generator;
            Rolls = new List<Roll>();
        }
        public int Score { get => throw new NotImplementedException(); }
        public bool LastFrame { get => _lastFrame; set => _lastFrame = value; }
        public IGenerator Generator { get => _generator; set => _generator = value; }
        public List<Roll> Rolls { get => rolls; set => rolls = value; }

        public bool Roll()
        {
            throw new NotImplementedException();
        }
    }
}
