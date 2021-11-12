using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal class Data1TextLanguageSection
    {
        readonly int fileCount = 1803;
        readonly int data0EntryLength = 32;
        readonly int amData0Offset = 302944;
        readonly int euData0Offset = 360640;

        byte[] data0;
        int data0Offset;

        List<Data1TextFileDecipher> files;

        public Data1TextLanguageSection(byte[] buffer, string language)
        {
            if (language == "am")
                data0Offset = amData0Offset;
            if (language == "eu")
                data0Offset = euData0Offset;
            files = new List<Data1TextFileDecipher>();
            Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fire_Emblem_Three_Houses_Randomizer_V2.DATA0.bin");
            data0 = new byte[stream.Length];
            stream.Read(data0, 0, data0.Length);
            int currentData0Offset = data0Offset;
            for (int i = 0; i < fileCount; i++)
            {
                if (BitConverter.ToUInt64(data0, currentData0Offset + 8) > 0)
                {
                    int localOffset = (int)(BitConverter.ToUInt64(data0, currentData0Offset) - (ulong)Randomizer.textSectionOffset);
                    files.Add(new Data1TextFileDecipher(buffer, localOffset));
                }
                else
                    files.Add(null);
                currentData0Offset += data0EntryLength;
            }
        }

        public byte[] getBytes()
        {
            byte[] bytes = new byte[Randomizer.textSectionLength];
            int currentData0Offset = data0Offset;
            for (int i = 0; i < fileCount; i++)
            {
                int localOffset = (int)(BitConverter.ToUInt64(data0, currentData0Offset) - (ulong)Randomizer.textSectionOffset);
                if (files[i] != null)
                    files[i].getBytes().CopyTo(bytes, localOffset);
                currentData0Offset += data0EntryLength;
            }
            return bytes;
        }

        public List<string> getStrings(bool includeInvalids)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < files.Count; i++)
                if (files[i] != null)
                    strings.AddRange(files[i].getStrings(includeInvalids));
            return strings;
        }

        public void setStrings(List<string> strings, bool includeInvalids)
        {
            for (int i = 0; i < files.Count; i++)
                if (files[i] != null)
                    files[i].setStrings(strings, includeInvalids);
        }
    }
}