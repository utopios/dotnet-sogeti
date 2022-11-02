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
        public int Score { 
            get
            {
                int score = 0;
                Rolls.ForEach(r =>
                {
                    score += r.Pins;
                });
                return score;
            }
        }
        public bool LastFrame { get => _lastFrame; set => _lastFrame = value; }
        public IGenerator Generator { get => _generator; set => _generator = value; }
        public List<Roll> Rolls { get => rolls; set => rolls = value; }


        private void MakeRoll(int max)
        {
            int pins = _generator.RandomPins(max);
            Rolls.Add(new Roll(pins));
        }

        public bool Roll()
        {
            if(Rolls.Count == 0 || (Rolls.Count == 1 && Rolls[0].Pins == 10 && LastFrame))
            {
                MakeRoll(10);
                return true;
            }
            else if(Rolls.Count == 1 && !(Rolls[0].Pins == 10 && !LastFrame))
            {
                MakeRoll(10 - Rolls[0].Pins);
                return true;
            }
            else if(Rolls.Count == 2 && LastFrame)
            {
                Roll r1 = Rolls[0];
                Roll r2 = Rolls[1];

                if((r1.Pins + r2.Pins) >= 10 && (r1.Pins + r2.Pins) < 20)
                {
                    MakeRoll(20 - (r1.Pins + r2.Pins));
                    return true;
                }
                else if((r1.Pins + r2.Pins) == 20)
                {
                    MakeRoll(10);
                    return true;
                }
            }
            return false;
        }
    }
}
