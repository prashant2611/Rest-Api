using Sold.Machine.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sold_Machine_Project.Services
{
    public class MachineDetailRepository : IMachineDetailRepository
    {
        private FileReader _data = new FileReader("matrix.csv");
        private IEnumerable<AssetInfo> _assets;
        public MachineDetailRepository()
        {
            _assets = _data.ReadFileContent();
        }


        public List<string> GetAssetForMachineType(string machineName)   
        {
            List<string> assetList = new List<string>();
            assetList = _assets.Where(x => x.machineName == machineName).Select(x => x.assetName).ToList();

            /*foreach (var asset in Assets)
            {
                if (asset._machineName == MachineName)
                {
                    AssetList.Add(asset._assetName);
                }
            }*/
            return assetList;
        }

        public List<string> GetMachineTypeForAsset(string assetName)
        {
            List<string> machineList = new List<string>();
            machineList = _assets.Where(x => x.assetName == assetName).Select(x => x.machineName).ToList();

            /*foreach (var asset in Assets)
            {
                if (asset._assetName == AssetName)
                {
                    MachineList.Add(asset._machineName);
                }
            }*/
            return machineList;
        }

        public List<string> GetMachineTypeUseLetestAsset()
        {
            List<string> useOldSeriesAsset = new List<string>();
            List<string> letestSeries = new List<string>();

            var maxAssetSeries = _assets.GroupBy(assetName => assetName.assetName)
                                       .Select(grp => new
                                       {
                                           grp.Key,
                                           max = grp.OrderByDescending(x => x.assetSeries)
                                                    .FirstOrDefault().assetSeries
                                       })
                                       .ToList();

            foreach (var Asset in _assets)
            {
                if (!(Asset.assetSeries == maxAssetSeries.Where(x => x.Key == Asset.assetName).Select(x => x.max).FirstOrDefault()))
                {
                    useOldSeriesAsset.Add(Asset.machineName);
                }
            }

            foreach (var part in _assets.Select(x => x.machineName).Except(useOldSeriesAsset))
            {
                letestSeries.Add(part);
            }
            
            return letestSeries;
        }
    }
}
