using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    public class Data1TextFormatter : TextFormatter
    {
        readonly long euOffset = 6119094304;

        List<Data1TextLanguageSection> languages;

        public Data1TextFormatter(byte[] buffer)
        {
            languages = new List<Data1TextLanguageSection>();
            languages.Add(new Data1TextLanguageSection(buffer, "am"));
            languages.Add(new Data1TextLanguageSection(buffer, "eu"));
        }

        public override byte[] getBytes()
        {
            byte[] bytes = languages[0].getBytes();
            byte[] euBytes = languages[1].getBytes();
            for (int i = (int)(euOffset - Randomizer.textSectionOffset); i < bytes.Length; i++)
                bytes[i] = euBytes[i];
            return bytes;
        }

        public override List<string> getStrings(bool includeInvalids)
        {
            return languages[0].getStrings(includeInvalids);
        }

        public override void setStrings(List<string> strings, bool includeInvalids)
        {
            List<string> euStrings = new List<string>();
            euStrings.AddRange(strings);
            languages[0].setStrings(strings, includeInvalids);
            languages[1].setStrings(euStrings, includeInvalids);
        }
    }
}
