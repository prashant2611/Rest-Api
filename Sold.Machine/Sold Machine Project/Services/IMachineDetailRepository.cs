using Sold.Machine.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sold_Machine_Project.Services
{
    public interface IMachineDetailRepository
    {
       

        List<string> GetAssetForMachineType(string machineName);
        List<string> GetMachineTypeForAsset(string assetName);
        List<string> GetMachineTypeUseLetestAsset();
    }
}
