using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppDeviceMaster
    {
        public int DeviceID { get; }
        public string DeviceIP { get; }
        public string DeviceName { get; }
        public string SourcePath { get; }
        public string DestinationPath { get; }
        public string FileType { get; }
        public string ScrollText { get; }
        public int Lang { get; }
        public int IsUpdate { get; }
        public string Regsitration_Date { get; }
        public string Expiry_Date { get; }
        public string Lic_Customer_Licesnse_Id { get; }
        public string Lic_Product_Id { get; }
        public string Lic_Code { get; }
        public string License_Key { get; }

        public AppDeviceMaster(
            int _DeviceID
          , string _DeviceIP
          , string _DeviceName
          , string _SourcePath
          , string _DestinationPath
          , string _FileType
          , string _ScrollText
          , int _Lang
          , int _IsUpdate
          , string _regsitration_date
          , string _expiry_date
          , string _lic_customer_licesnse_Id
          , string _lic_product_id
          , string _lic_code
          , string _license_key
            )
        {
            DeviceID = _DeviceID;
            DeviceIP = _DeviceIP;
            DeviceName = _DeviceName;
            SourcePath = _SourcePath;
            DestinationPath = _DestinationPath;
            FileType = _FileType;
            ScrollText = _ScrollText;
            Lang = _Lang;
            IsUpdate = _IsUpdate;
            Regsitration_Date = _regsitration_date;
            Expiry_Date = _expiry_date;
            Lic_Customer_Licesnse_Id = _lic_customer_licesnse_Id;
            Lic_Product_Id = _lic_product_id;
            Lic_Code = _lic_code;
            License_Key = _license_key;
        }

        public AppDeviceMaster()
        {
            DeviceID = 0;
            DeviceIP = "";
            DeviceName = "";
            SourcePath = "";
            DestinationPath = "";
            FileType = "";
            ScrollText = "";
            Lang = 0;
            IsUpdate = 0;
            Regsitration_Date = "";
            Expiry_Date = "";
            Lic_Customer_Licesnse_Id = "";
            Lic_Product_Id = "";
            Lic_Code = "";
            License_Key = "";
        }
    }
}
