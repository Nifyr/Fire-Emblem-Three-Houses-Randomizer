using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal class Data1TextFileDecipher
    {
        Data1TextFile file;
        public Data1TextFileDecipher (byte[] buffer, int fileOffset)
        {
            if (BitConverter.ToUInt32(buffer, fileOffset + 4) == 1)
                file = new Data1RawTextFile(buffer, fileOffset);
            else
                file = new Data1ConvoTextFile(buffer, fileOffset);
        }

        public List<byte> getBytes()
        {
            return file.getBytes();
        }

        public List<string> getStrings(bool includeInvalids)
        {
            return file.getStrings(includeInvalids);
        }

        public void setStrings(List<string> strings, bool includeInvalids)
        {
            file.setStrings(strings, includeInvalids);
        }

    }

    abstract internal class Data1TextFile
    {
        abstract public List<byte> getBytes();
        abstract public List<string> getStrings(bool includeInvalids);
        abstract public void setStrings(List<string> strings, bool includeInvalids);
    }

    internal class Data1RawTextFile : Data1TextFile
    {
        uint unk1;
        uint unk2;
        uint header1Size;
        uint header2Size;
        uint lineCount;
        List<uint> linePointers;
        uint linesEnd;
        List<TextBinLine> lines;

        public Data1RawTextFile(byte[] buffer, int fileOffset)
        {
            int offset = fileOffset;
            unk1 = BitConverter.ToUInt32(buffer, offset + 0);
            unk2 = BitConverter.ToUInt32(buffer, offset + 4);
            header1Size = BitConverter.ToUInt32(buffer, offset + 8);
            header2Size = BitConverter.ToUInt32(buffer, offset + 12);
            lineCount = BitConverter.ToUInt32(buffer, offset + 16);
            offset += (int)header1Size;
            linePointers = new List<uint>();
            lines = new List<TextBinLine>();
            for (int i = 0; i < lineCount; i++)
            {
                linePointers.Add(BitConverter.ToUInt32(buffer, offset));
                lines.Add(new TextBinLine(buffer, (uint)fileOffset + header1Size + header2Size + linePointers[i]));
                offset += 4;
            }
            linesEnd = BitConverter.ToUInt32(buffer, offset);
        }

        public override List<byte> getBytes()
        {
            fixPointers();
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(unk1));
            bytes.AddRange(BitConverter.GetBytes(unk2));
            bytes.AddRange(BitConverter.GetBytes(header1Size));
            bytes.AddRange(BitConverter.GetBytes(header2Size));
            bytes.AddRange(BitConverter.GetBytes(lineCount));
            for (int i = 0; i < lines.Count; i++)
                bytes.AddRange(BitConverter.GetBytes(linePointers[i]));
            bytes.AddRange(BitConverter.GetBytes(linesEnd));
            for (int i = 0; i < lines.Count; i++)
                bytes.AddRange(lines[i].getBytes());
            return bytes;
        }

        private void fixPointers()
        {
            header1Size = 20;
            header2Size = (uint)(lines.Count + 1) * 4;
            uint offset = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                linePointers[i] = offset;
                offset += (uint)lines[i].getBytes().Count;
            }
            linesEnd = offset;

        }

        public override List<string> getStrings(bool includeInvalids)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].valid() || includeInvalids)
                    strings.Add(lines[i].getString());
            return strings;
        }

        public override void setStrings(List<string> strings, bool includeInvalids)
        {
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].valid() || includeInvalids)
                    lines[i].setString(strings);
        }
    }

    internal class Data1ConvoTextFile : Data1TextFile
    {
        uint lineCount;
        List<uint> linePointers;
        List<uint> lineSizes;
        List<ConvoLine> lines;

        public Data1ConvoTextFile(byte[] buffer, int fileOffset)
        {
            lineCount = BitConverter.ToUInt32(buffer, fileOffset);
            linePointers = new List<uint>();
            lineSizes = new List<uint>();
            lines = new List<ConvoLine>();
            int offset = fileOffset + 4;
            for (int i = 0; i < lineCount; i++)
            {
                linePointers.Add(BitConverter.ToUInt32(buffer, offset + 0));
                lineSizes.Add(BitConverter.ToUInt32(buffer, offset + 4));
                lines.Add(new ConvoLine(buffer, (uint)(fileOffset + linePointers[i])));
                offset += 8;
            }
        }

        public override List<byte> getBytes()
        {
            fixPointers();
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(lineCount));
            for (int i = 0; i < lines.Count; i++)
            {
                bytes.AddRange(BitConverter.GetBytes(linePointers[i]));
                bytes.AddRange(BitConverter.GetBytes(lineSizes[i]));
            }
            for (int i = 0; i < lines.Count; i++)
                bytes.AddRange(lines[i].getBytes());
            return bytes;
        }

        private void fixPointers()
        {
            int offset = 8 * lines.Count + 4;
            for (int i = 0; i < lines.Count; i++)
            {
                linePointers[i] = (uint)offset;
                lineSizes[i] = (uint)lines[i].getBytes().Count - 2;
                offset += (int)lineSizes[i] + 2;
            }
        }

        public override List<string> getStrings(bool includeInvalids)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].valid() || includeInvalids)
                    strings.Add(lines[i].getString());
            return strings;
        }

        public override void setStrings(List<string> strings, bool includeInvalids)
        {
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].valid() || includeInvalids)
                    lines[i].setString(strings);
        }
    }
}