using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangChunkReader<THeader>
    {
        private BinaryReader reader;
        private List<BangChunkEntry> entries = new List<BangChunkEntry>();

        public THeader Header { get; set; } = default(THeader);

        public BangChunkReader(BinaryReader reader)
        {
            this.reader = reader;
        }
        
        public void ReadExpectedTag(ushort expectedTag)
        {
            ushort readTag = reader.ReadUInt16();
            if (readTag != expectedTag)
                throw new InvalidOperationException($"Expected tag {expectedTag} but got tag {readTag}");

            uint readData = reader.ReadUInt32();
            entries.Add(new BangChunkEntry()
            {
                Tag = readTag,
                Data = readData
            });
        }

        public void ReadExpectedTagAndSkip(ushort expectedTag)
        {
            ReadExpectedTag(expectedTag);
            var bytesToSkip = entries[entries.Count - 1].Data;

            reader.BaseStream.Seek(bytesToSkip, SeekOrigin.Current);
        }

        public int ReadExpectedTagValue(ushort expectedTag)
        {
            ReadExpectedTag(expectedTag);
            return reader.ReadInt32();
        }

        public int ReadInt32IfTagged(ushort tag)
        {
            ushort readTag = reader.ReadUInt16();
            uint readData = reader.ReadUInt32();
            if (readTag == tag)
                return reader.ReadInt32();

            return -1;
        }

        public string ReadString()
        {
            int len = reader.ReadInt32();
            if (len <= 0)
                return "";

            byte[] strData = reader.ReadBytes(len * 2);
            return Encoding.Unicode.GetString(strData);
        }

        public string ReadASCIIString()
        {
            int size = reader.ReadInt32();
            return ReadASCIIString(size);
        }

        public string ReadASCIIString(int len)
        {
            byte[] strData = reader.ReadBytes(len);
            var str = Encoding.ASCII.GetString(strData);

            if (str.EndsWith('\0'))
                return str.Substring(0, str.Length - 1);
            return str;
        }

        public uint ReadUInt32() => reader.ReadUInt32();
        public int ReadInt32() => reader.ReadInt32();
        public bool ReadBoolean() => reader.ReadBoolean();
        public float ReadFloat() => reader.ReadSingle();

        public T ReadEnum<T>() where T : Enum => (T)(object)reader.ReadInt32(); 

    }
}
