using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zonk
{
    internal class BonesCombinator
    {
        private int _minimalSideValue;
        private int _maximalSideValue;
        private int _sidesNumber;

        public BonesCombinator(int minimalSideValue, int maximalSideValue)
        {
            if(minimalSideValue > maximalSideValue)
                throw new ArgumentException($"{nameof(minimalSideValue)} must be <= {nameof(maximalSideValue)}");

            _minimalSideValue = minimalSideValue;
            _maximalSideValue = maximalSideValue;
            _sidesNumber = maximalSideValue - minimalSideValue + 1;
        }

        public BonesCombinator(int maximalSideValue) : this(BonesConstants.MINIMAL_SIDE_VALUE_DEFAULT, maximalSideValue) { }

        public BonesCombinator() : this(BonesConstants.MINIMAL_SIDE_VALUE_DEFAULT, BonesConstants.MAXIMAL_SIDE_VALUE_DEFAULT) { }

        public BonesCombinator(Cup cup) : this(cup.MinimalSideValue, cup.MaximalSideValue) { }

        public int[] Combinate(int[] bones)
        {
            int[] result = new int[_sidesNumber];

            for(int i = 0; i < bones.Length; i++)
                result[bones[i] - _minimalSideValue]++;

            return result;
        }

        public string AsString(int[] combination)
        {
            string result = "";

            for(int i = 0; i < combination.Length - 1; i++)
                result += $"[{i + _minimalSideValue}] - {combination[i]}, ";

            result += $"[{_maximalSideValue}] - {combination[combination.Length - 1]}";

            return result;
        }
    }
}
