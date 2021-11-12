using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal class TextBinLanguageSection
    {
        uint tableCount;
        List<uint> tablePointers;
        List<uint> tableSizes;
        List<TextBinTable> tables;

        public TextBinLanguageSection (byte[] buffer, uint languagePointer)
        {
            int offset = (int)languagePointer;
            tableCount = BitConverter.ToUInt32(buffer, offset);
            offset += 4;

            tablePointers = new List<uint>();
            tableSizes = new List<uint>();
            tables = new List<TextBinTable>();
            for (int i = 0; i < tableCount; i++)
            {
                tablePointers.Add(BitConverter.ToUInt32(buffer, offset + 0));
                tableSizes.Add(BitConverter.ToUInt32(buffer, offset + 4));
                tables.Add(new TextBinTable(buffer, languagePointer + tablePointers[i]));
                offset += 8;
            }
        }

        public List<byte> getBytes()
        {
            fixPointers();
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(tableCount));
            for (int i = 0; i < tables.Count; i++)
            {
                bytes.AddRange(BitConverter.GetBytes(tablePointers[i]));
                bytes.AddRange(BitConverter.GetBytes(tableSizes[i]));
            }
            for (int i = 0; i < tables.Count; i++)
                bytes.AddRange(tables[i].getBytes());
            return bytes;
        }

        private void fixPointers()
        {
            uint offset = 4;
            for (int i = 0; i < tables.Count; i++)
                offset += 8;
            for (int i = 0; i < tables.Count; i++)
            {
                tablePointers[i] = offset;
                tableSizes[i] = (uint)tables[i].getBytes().Count;
                tables[i].fixPointers(tableSizes[i]);
                offset += tableSizes[i];
            }
        }

        public List<string> getStrings(bool includeInvalids)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < tables.Count; i++)
                strings.AddRange(tables[i].getStrings(includeInvalids));
            return strings;
        }

        public void setStrings(List<string> strings, bool includeInvalids)
        {
            for (int i = 0; i < tables.Count; i++)
                tables[i].setStrings(strings, includeInvalids);
        }
    }
}