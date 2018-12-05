using System.Collections;
using System.Collections.Generic;

namespace LogicCircuit.Test
{
    public class TruthTable2 : IEnumerable<TruthValue2>
    {
        private readonly bool[] values = { true, false };
        private readonly Dictionary<bool, Dictionary<bool, bool>> table = new Dictionary<bool, Dictionary<bool, bool>>();

        public TruthTable2()
        {
            foreach(var value in values)
            {
                var dictionary = new Dictionary<bool, bool>();
                foreach(var value2 in values) dictionary.Add(value2, false);
                table.Add(value, dictionary);
            }
        }

        public TruthTable2(bool a, bool b, bool c, bool d)
            :this()
        {
            this[false, false] = a;
            this[false, true] = b;
            this[true, false] = c;
            this[true, true] = d;
        }

        public bool this[bool a, bool b]
        {
            get
            {
                return table[a][b];
            }
            set
            {
                table[a][b] = value;
            }
        }

        public IEnumerator<TruthValue2> GetEnumerator()
        {
            var list = new List<TruthValue2>();
            foreach(var kvp in table)
            {
                foreach(var kvp2 in kvp.Value)
                {
                    list.Add(new TruthValue2
                    {
                        A = kvp.Key,
                        B = kvp2.Key,
                        C = kvp2.Value
                    });
                }
            }

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
