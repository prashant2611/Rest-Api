using System;
using System.Collections.Generic;
using System.Text;

namespace Sold.Machine.Service
{
    public class AssetInfo
    {
        public int id { get; set; }
        public string machineName { get; set; }  
        public string assetName { get; set; }
        public string assetSeries { get; set; }

        public AssetInfo(int id,string machineName,string assetName,string assetSeries)
        {
            this.id = id;
            this.machineName = machineName;
            this.assetName = assetName;
            this.assetSeries = assetSeries;
        }
    }
}
