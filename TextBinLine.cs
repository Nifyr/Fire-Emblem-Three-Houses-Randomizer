using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    internal class TextBinLine
    {
        List<byte> encodedText;

        public TextBinLine (byte[] buffer, uint linePointer)
        {
            int offset = (int)linePointer;
            encodedText = new List<byte>();
            while (buffer[offset] != 0)
            {
                encodedText.Add(buffer[offset]);
                offset++;
            }
            encodedText.Add(0);
        }

        public List<byte> getBytes()
        {
            return encodedText;
        }

        public string getString()
        {
            byte[] utf8Bytes = new byte[encodedText.Count - 1];
            for (int i = 0; i < utf8Bytes.Length; i++)
                utf8Bytes[i] = encodedText[i];
            UTF8Encoding utf8 = new UTF8Encoding();
            return utf8.GetString(utf8Bytes);
        }

        public void setString(List<string> strings)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] utf8Bytes = utf8.GetBytes(strings[0]);
            encodedText = new List<byte>();
            for (int i = 0; i < utf8Bytes.Length; i++)
                encodedText.Add(utf8Bytes[i]);
            encodedText.Add(0);
            strings.RemoveAt(0);
        }

        public bool valid()
        {
            bool hasInvalidChar = false;
            for (int i = 0; i < getString().Length && !hasInvalidChar; i++)
                if (getString().ElementAt(i) >= 0x3040)
                    hasInvalidChar = true;

            return encodedText.Count > 1 &&
                !hasInvalidChar &&
                getString() != "iron_untranslated" &&
                getString().ToLower() != "dummy" &&
                getString() != "Unused" &&
                !getString().StartsWith("Spare") &&
                !getString().StartsWith("Character exclusive spare") &&
                getString() != "-" &&
                getString() != " " &&
                !getString().StartsWith("Placeholder") &&
                getString() != "0" &&
                !(getString().StartsWith("Item ") && getString().Length == 7) &&
                !getString().StartsWith("Dish ") &&
                !(getString().StartsWith("Bait ") && getString().Length == 7) &&
                !getString().StartsWith("seeds") &&
                !getString().StartsWith("Ore ") &&
                !(getString().StartsWith("Fish ") && getString().Length == 7) &&
                !getString().StartsWith("Crops") &&
                !(getString().StartsWith("Meat ") && getString().Length == 7) &&
                !getString().StartsWith("Tea Leaves ") &&
                getString() != "TBD" &&
                getString() != "On Hold" &&
                getString() != "Undecided" &&
                !getString().StartsWith("Dining Together Menu Item") &&
                !getString().StartsWith("Reserved") &&
                getString() != "Map Battle Boss Reserved" &&
                !getString().StartsWith("conversation event placeholder") &&
                !getString().StartsWith("Accepted Quest Character Message") &&
                !getString().StartsWith("Mission text message") &&
                !getString().StartsWith("Quest Reported Character Message") &&
                !getString().StartsWith("Sothis Message") &&
                !getString().Contains("") &&
                getString() != "tTemporarymessage";
        }
    }

    internal class ConvoLine
    {
        readonly int preLineLength = 6;
        
        List<byte> preLine;
        List<byte> encodedText;
        List<byte> postLine;

        public ConvoLine(byte[] buffer, uint linePointer)
        {
            int offset = (int)linePointer;
            preLine = new List<byte>();
            encodedText = new List<byte>();
            postLine = new List<byte>();
            for (int i = 0; i < preLineLength; i++)
            {
                preLine.Add(buffer[offset]);
                offset++;
            }
            while (buffer[offset] != 239)
            {
                encodedText.Add(buffer[offset]);
                offset++;
            }
            while (buffer[offset] != 0)
            {
                postLine.Add(buffer[offset]);
                offset++;
            }
            postLine.Add(0);
        }

        public List<byte> getBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(preLine);
            bytes.AddRange(encodedText);
            bytes.AddRange(postLine);
            return bytes;
        }

        public string getString()
        {
            byte[] utf8Bytes = new byte[encodedText.Count];
            for (int i = 0; i < utf8Bytes.Length; i++)
                utf8Bytes[i] = encodedText[i];
            UTF8Encoding utf8 = new UTF8Encoding();
            return utf8.GetString(utf8Bytes);
        }

        public void setString(List<string> strings)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] utf8Bytes = utf8.GetBytes(strings[0]);
            encodedText = new List<byte>();
            for (int i = 0; i < utf8Bytes.Length; i++)
                encodedText.Add(utf8Bytes[i]);
            strings.RemoveAt(0);
        }

        public bool valid()
        {
            bool hasInvalidChar = false;
            for (int i = 0; i < getString().Length && !hasInvalidChar; i++)
                if (getString().ElementAt(i) >= 0x3040)
                    hasInvalidChar = true;

            return getString().Length > 0 && !hasInvalidChar && getString() != "NULL#00";
        }
    }
}