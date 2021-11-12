using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal class TextBinTable
    {
        uint magic;
        ushort tableSize;
        ushort flagCount;
        ushort messageCount;
        ushort pointerSize;
        uint headerSize;
        List<byte> flags;
        List<TextBinMessage> messages;

        public TextBinTable (byte[] buffer, uint tablePointer)
        {
            int offset = (int)tablePointer;
            magic = BitConverter.ToUInt32(buffer, offset + 0);
            tableSize = BitConverter.ToUInt16(buffer, offset + 4);
            flagCount = BitConverter.ToUInt16(buffer, offset + 6);
            messageCount = BitConverter.ToUInt16(buffer, offset + 8);
            pointerSize = BitConverter.ToUInt16(buffer, offset + 10);
            headerSize = BitConverter.ToUInt32(buffer, offset + 12);
            offset += 16;
            flags = new List<byte>();
            for (int i = 0; i < flagCount; i++)
                flags.Add(buffer[offset + i]);
            offset = (int)(tablePointer + headerSize);
            messages = new List<TextBinMessage>();
            for (int i = 0; i < messageCount; i++)
            {
                messages.Add(new TextBinMessage(buffer, (uint)offset, tablePointer + headerSize, flags));
                offset += pointerSize;
            }
        }

        public List<byte> getBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(magic));
            bytes.AddRange(BitConverter.GetBytes(tableSize));
            bytes.AddRange(BitConverter.GetBytes(flagCount));
            bytes.AddRange(BitConverter.GetBytes(messageCount));
            bytes.AddRange(BitConverter.GetBytes(pointerSize));
            bytes.AddRange(BitConverter.GetBytes(headerSize));
            for (int i = 0; i < flags.Count; i++)
                bytes.Add(flags[i]);
            while (bytes.Count < headerSize)
                bytes.Add(255);
            for (int i = 0; i < messages.Count; i++)
                bytes.AddRange(messages[i].getPointerBytes());
            for (int i = 0; i < messages.Count; i++)
                bytes.AddRange(messages[i].getLineBytes());
            return bytes;
        }

        public void fixPointers(uint tableSize)
        {
            this.tableSize = (ushort)tableSize;
            uint offset = 0;
            for (int i = 0; i < messages.Count; i++)
                offset += (uint)messages[i].getPointerBytes().Count;
            for (int i = 0; i < messages.Count; i++)
            {
                messages[i].fixPointers(offset);
                offset += (uint)messages[i].getLineBytes().Count;
            }
        }

        public List<string> getStrings(bool includeInvalids)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < messages.Count; i++)
                strings.AddRange(messages[i].getStrings(includeInvalids));
            return strings;
        }

        public void setStrings(List<string> strings, bool includeInvalids)
        {
            for (int i = 0; i < messages.Count; i++)
                messages[i].setStrings(strings, includeInvalids);
        }
    }
}