using LogicCircuit.Infrastructure;
using System;
using System.Collections;

namespace LogicCircuit.Utilities
{
    public static class IntPinSeriesConverter
    {
        public static void Set(this PinSeries pinSeries, int value)
        {
            //Thanks SO
            //https://stackoverflow.com/questions/6758196/convert-int-to-a-bit-array-in-net
            var bitArray = new BitArray(BitConverter.GetBytes(value));
            for(var i=0; i<pinSeries.Length; i++)
            {
                pinSeries[i] = bitArray[i];
            }
        }

        public static int Read(this PinSeries pinSeries)
        {
            var bitArray = new BitArray(pinSeries.Length);
            for(var i=0; i<pinSeries.Length; i++)
            {
                bitArray[i] = pinSeries[i];
            }

            //Thanks SO
            //https://stackoverflow.com/questions/5283180/how-can-i-convert-bitarray-to-single-int

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
