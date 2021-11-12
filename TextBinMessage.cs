using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal class TextBinMessage
    {
        List<uint> linePointers;
        List<uint> otherEntries;
        List<TextBinLine> lines;

        public TextBinMessage (byte[] buffer, uint messagePointer, uint messageStart, List<byte> flags)
        {
            int offset = (int)messagePointer;
            linePointers = new List<uint>();
            otherEntries = new List<uint>();
            lines = new List<TextBinLine>();
            for (int i = 0; i < flags.Count; i++)
            {
                if (flags[i] == 0)
                {
                    linePointers.Add(BitConverter.ToUInt32(buffer, offset));
                    lines.Add(new TextBinLine(buffer, messageStart + linePointers[i]));
                }
                else
                    otherEntries.Add(BitConverter.ToUInt32(buffer, offset));
                offset += 4;
            }
        }

        public List<byte> getPointerBytes()
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < linePointers.Count; i++)
                bytes.AddRange(BitConverter.GetBytes(linePointers[i]));
            for (int i = 0; i < otherEntries.Count; i++)
                bytes.AddRange(BitConverter.GetBytes(otherEntries[i]));
            return bytes;
        }

        public List<byte> getLineBytes()
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < lines.Count; i++)
                bytes.AddRange(lines[i].getBytes());
            return bytes;
        }

        public void fixPointers(uint lineOffset)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                linePointers[i] = lineOffset;
                lineOffset += (uint)lines[i].getBytes().Count;
            }
        }

        public List<string> getStrings(bool includeInvalids)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].valid() || includeInvalids)
                    strings.Add(lines[i].getString());
            return strings;
        }

        public void setStrings(List<string> strings, bool includeInvalids)
        {
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].valid() || includeInvalids)
                    lines[i].setString(strings);
        }
    }
}