using RZPUtils;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RZGame.Core.ContentManagement
{
    public class RZPAKLoader
    {
        public RZPAKLoader() { }

        public Dictionary<string, byte[]> Load()
        {
            string packPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pack.rzpc");
            Dictionary<string, byte[]> files = new();

            if (!File.Exists(packPath))
            {
                throw new FileNotFoundException();
            }

            using (PackageReader reader = new(packPath))
            {
                Block foldersData = reader.ReadFoldersData();
                List<Block> assetsInfo = reader.ReadAssetsData(16 + foldersData.DataLength);

                int offset = 0;
                for(int i = 0; i < assetsInfo.Count; i++)
                {
                    string filename = Encoding.ASCII.GetString(assetsInfo[i].Data[0]);
                    int filesize = BinaryPrimitives.ReadInt32LittleEndian(assetsInfo[i].Data[2]);
                    byte[] compressedContent = reader.ReadContent(filesize, offset);
                    offset += compressedContent.Length;
                    byte[] content = reader.InflateContent(compressedContent);
                    files.Add(filename, content);
                }
            }

            return files;
        }
    }
}
