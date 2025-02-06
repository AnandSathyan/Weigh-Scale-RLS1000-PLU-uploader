using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppCompanySetup
    {

        public int ID { get; }
        public string CompanyName { get; }
        public string CompanyLogo { get; }
        public string CompanyPhone { get; }
        public string CompanyEmail { get; }
        public string CompanyAddress { get; }
        public string CompanyWebSite { get; }
        public byte[] CompanyImage { get; }
        public string CompanyCurrency { get; }
        public int CompanyDecimalPlace { get; }

        public AppCompanySetup(
            int _ID,
            string _CompanyName,
            string _CompanyLogo,
            string _CompanyPhone,
            string _CompanyEmail,
            string _CompanyAddress,
            string _CompanyWebSite,
            byte[] _CompanyImage,
            string _CompanyCurrency,
            int _CompanyDecimalPlace)
        {
            ID = _ID;
            CompanyName = _CompanyName;
            CompanyLogo = _CompanyLogo;
            CompanyPhone = _CompanyPhone;
            CompanyEmail = _CompanyEmail;
            CompanyAddress = _CompanyAddress;
            CompanyWebSite = _CompanyWebSite;
            CompanyImage = _CompanyImage;
            CompanyCurrency = _CompanyCurrency;
            CompanyDecimalPlace = _CompanyDecimalPlace;
        }
        public AppCompanySetup()
        {
            ID = 0;
            CompanyName = "";
            CompanyLogo = "";
            CompanyPhone = "";
            CompanyEmail = "";
            CompanyAddress = "";
            CompanyWebSite = "";
            CompanyImage = new byte[0];
            CompanyCurrency = "";
            CompanyDecimalPlace = 0;
        }
    }
}
