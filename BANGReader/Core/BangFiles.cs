using BANGReader.Core.Data;
using ComponentAce.Compression.Libs.zlib;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BANGReader.Core
{
    public static class BangFiles
    {
        private static readonly byte[] CompressMagic = Encoding.ASCII.GetBytes("l33t");

        private static BangChunkEntry ReadExpectedTag(BinaryReader reader, ushort expectedTag)
        {
            ushort readTag = reader.ReadUInt16();
            if (readTag != expectedTag)
                throw new InvalidOperationException($"Expected tag {expectedTag} but got tag {readTag}");

            uint readData = reader.ReadUInt32();
            return new BangChunkEntry()
            {
                Tag = readTag,
                Data = readData
            };
        }

        private static string ReadString(BinaryReader reader)
        {
            int len = reader.ReadInt32();
            if (len <= 0)
                return "";

            byte[] strData = reader.ReadBytes(len * 2);
            return Encoding.Unicode.GetString(strData);
        }

        private static string ReadASCIIString(BinaryReader reader, int len)
        {
            byte[] strData = reader.ReadBytes(len);
            return Encoding.ASCII.GetString(strData);
        }

        private static void ProcessStream(BinaryReader reader)
        {
            BangScenarioReader scReader = new BangScenarioReader(new BangChunkReader(reader));
            BangData data = scReader.ReadAll();

            /*
            var entry = ReadExpectedTag(reader, 0x4742);
            var fileVersion = reader.ReadUInt32();
            string creatorVersionInformation = fileVersion >= 25 ? ReadString(reader) : "Unknown";

            var lenUnkArray = fileVersion >= 4 ? reader.ReadInt32() : 0;
            string unkVal = ReadASCIIString(reader, lenUnkArray);

            if(fileVersion >= 23)
            {
                int unkVal2 = reader.ReadInt32();
                string unkStr2 = ReadString(reader);
            }

            long pos = reader.BaseStream.Position;

            if(fileVersion >= 33)
            {
                bool unkBool = reader.ReadBoolean();
            }
            */
        }

        public static void ReadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found {path}");

            // Check magic
            using(var sr = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                byte[] magic = sr.ReadBytes(4);
                if (!magic.SequenceEqual(CompressMagic))
                {
                    sr.BaseStream.Position = 0;
                    ProcessStream(sr);
                    return;
                }
                    

                uint archiveSize = sr.ReadUInt32();

                using (ZlibStream stream = new ZlibStream(sr.BaseStream, CompressionMode.Decompress, CompressionLevel.Default, true))
                using (BinaryReader binaryStreamReader = new BinaryReader(stream))
                {
                    stream.BufferSize = 32000;

                    ProcessStream(new BinaryReader(stream));
                }
            }


        }

    }
}
