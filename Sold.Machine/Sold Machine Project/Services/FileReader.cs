using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sold.Machine.Service
{
    public class FileReader
    {
        private string path;
        int count = 0;

        public FileReader(string path)
        {
            this.path = path;
        }

        public List<AssetInfo> ReadFileContent()
        {
            List<AssetInfo> assets = new List<AssetInfo>();
            string csvline;

            using (StreamReader sr = new StreamReader(path))
            {
                while ((csvline = sr.ReadLine()) != null)
                {
                    assets.Add(ReadAssetFromFile(csvline));
                }
            }

            return assets;
        }

        AssetInfo ReadAssetFromFile(string fileLine)
        {
            string[] parts = fileLine.Split(',');
            int id = ++count;
            string machineName = parts[0];
            string assetName = parts[1];
            string assetSeries = parts[2];
            AssetInfo asset = new AssetInfo(id,machineName, assetName, assetSeries);
            return asset;
        }
    }
}
