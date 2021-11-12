using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    public abstract class TextFormatter
    {
        public abstract byte[] getBytes();
        public abstract List<string> getStrings(bool includeInvalids);
        public abstract void setStrings(List<string> strings, bool includeInvalids);
    }
}