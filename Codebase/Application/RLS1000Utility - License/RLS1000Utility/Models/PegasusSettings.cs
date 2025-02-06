using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class PegasusSettings
    {
        public int ID { get; }
        public string RegisterationCode { get; }
        public string Email { get; }
        public string Name { get; }
        public string CompanyName { get; }
        public string PhoneNumber { get; }
        public string VersionType { get; }
        public string LicenseKey { get; }

        public PegasusSettings(
            int _ID,
            string _RegisterationCode,
            string _Email,
            string _Name,
            string _CompanyName,
            string _PhoneNumber,
            string _VersionType,
            string _LicenseKey)
        {
            ID = _ID;
            RegisterationCode = _RegisterationCode;
            Email = _Email;
            Name = _Name;
            CompanyName = _CompanyName;
            PhoneNumber = _PhoneNumber;
            VersionType = _VersionType;
            LicenseKey = _LicenseKey;
        }
        public PegasusSettings()
        {
            ID = 0;
            RegisterationCode = "";
            Email = "";
            Name = "";
            CompanyName = "";
            PhoneNumber = "";
            VersionType = "";
            LicenseKey = "";
        }
    }
}
