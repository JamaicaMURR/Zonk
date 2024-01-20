using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zonk
{
    internal class Cup
    {
        private static Random rnd = new Random();

        public int MinimalSideValue { get; }
        public int MaximalSideValue { get => _maxPlusOneSideValue - 1; }

        private int _maxPlusOneSideValue;

        public Cup(int minimalSideValue, int maximalSideValue)
        {
            if(minimalSideValue > maximalSideValue)
                throw new ArgumentException($"{nameof(minimalSideValue)} must be <= {nameof(maximalSideValue)}");

            MinimalSideValue = minimalSideValue;
            _maxPlusOneSideValue = maximalSideValue + 1;
        }

        public Cup(int maximalSideValue) : this(BonesConstants.MINIMAL_SIDE_VALUE_DEFAULT, maximalSideValue) { }

        public Cup():this(BonesConstants.MINIMAL_SIDE_VALUE_DEFAULT, BonesConstants.MAXIMAL_SIDE_VALUE_DEFAULT) { }

        public int DropBone() => rnd.Next(MinimalSideValue, _maxPlusOneSideValue);

        public int[] DropBones(int count)
        {
            int[] result = new int[count];

            for(int i = 0; i < count; i++)
                result[i] = DropBone();

            return result;
        }

        public string AsString(int[]bones)
        {
            string result = "";

            for(int i = 0; i < bones.Length - 1; i++)
                result += $"{bones[i]}, ";

            result += $"{bones[bones.Length - 1]}";

            return result;
        }
    }
}
