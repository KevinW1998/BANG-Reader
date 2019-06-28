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
                DataLen = readData
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

        private static void ProcessStream(BinaryReader reader, BangGameTarget target, BangGameType type)
        {
            BangScenarioReader scReader = new BangScenarioReader(new BangChunkReader<BangDataHeader>(reader));
            BangData data = scReader.ReadAll(target, type);

        }

        public static void ReadFromFile(string path, BangGameTarget target = BangGameTarget.TryDetect, BangGameType type = BangGameType.TryDetect)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found {path}");

            if(target == BangGameTarget.TryDetect)
            {
                string pathExt = Path.GetExtension(path).ToLower();
                switch(pathExt)
                {
                    case ".sav":
                    case ".scn":
                    case ".rec":
                    case ".scx":
                    case ".rcx":
                        target = BangGameTarget.AgeOfMythology;
                        break;
                    case ".age3ysav":
                    case ".age3yscn":
                    case ".age3yrec":
                    case ".age3xsav":
                    case ".age3xscn":
                    case ".age3xrec":
                    case ".age3sav":
                    case ".age3scn":
                    case ".age3rec":
                        target = BangGameTarget.AgeOfEmpires3;
                        break;
                    case ".age4sav":
                    case ".age4scn":
                    case ".age4rec":
                        target = BangGameTarget.AgeOfEmpiresOnline;
                        break;
                    default:
                        throw new InvalidOperationException("Failed to detect game target");
                }
            }

            if (type == BangGameType.TryDetect)
            {
                string pathExt = Path.GetExtension(path).ToLower();
                switch (pathExt)
                {
                    case ".sav":
                    case ".age3ysav":
                    case ".age3xsav":
                    case ".age3sav":
                    case ".age4sav":
                        type = BangGameType.Save;
                        break;
                    case ".scn":
                    case ".scx":
                    case ".age3yscn":
                    case ".age3xscn":
                    case ".age3scn":
                    case ".age4scn":
                        type = BangGameType.Scenario;
                        break;
                    case ".rec":
                    case ".rcx":
                    case ".age3yrec":
                    case ".age3xrec":
                    case ".age3rec":
                    case ".age4rec":
                        type = BangGameType.Recorded;
                        break;
                    default:
                        throw new InvalidOperationException("Failed to detect game type");
                }
            }

                // Check magic
                using (var sr = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                byte[] magic = sr.ReadBytes(4);
                if (!magic.SequenceEqual(CompressMagic))
                {
                    sr.BaseStream.Position = 0;
                    ProcessStream(sr, target, type);
                    return;
                }
                    

                uint archiveSize = sr.ReadUInt32();

                using (ZlibStream stream = new ZlibStream(sr.BaseStream, CompressionMode.Decompress, CompressionLevel.Default, true))
                using (BinaryReader binaryStreamReader = new BinaryReader(stream))
                {
                    stream.BufferSize = 32000;

                    ProcessStream(new BinaryReader(stream), target, type);
                }
            }


        }

    }
}
