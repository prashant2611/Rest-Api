using System;
using System.Collections.Generic;
using System.Text;

namespace Sold.Machine.Service
{
    public class AssetInfo
    {
        public string machineName { get; }  
        public string assetName { get; }
        public string assetSeries { get; }

        public AssetInfo(string machineName,string assetName,string assetSeries)
        {
            this.machineName = machineName;
            this.assetName = assetName;
            this.assetSeries = assetSeries;
        }
    }
}
