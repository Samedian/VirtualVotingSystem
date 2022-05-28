using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystem
{
    public class GenerateID : IGenerateID
    {
        public string GenerateId(UserDetailEntity userDetailEntity)
        {
            string VVId = null;
            
            if (userDetailEntity.GetAddressDetail.State.Equals("Andhra Pradesh"))
                VVId += APDistrictCode(userDetailEntity.GetAddressDetail.District);
            else
              if (userDetailEntity.GetAddressDetail.State.Equals("Arunachal Pradesh"))
                VVId += ANDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Assam"))
                VVId += ASDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Bihar"))
                VVId += BIDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Chhattisgarh"))
                VVId += CHDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Goa"))
                VVId += GODistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Gujarat"))
                VVId += GJDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Haryana"))
                VVId += HYDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Himachal Pradesh"))
                VVId += HPDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Jharkhand"))
                VVId += JHDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Karnataka"))
                VVId += KNDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Kerala"))
                VVId += KLDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Madhya Pradesh"))
                VVId += MPDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Maharashtra"))
                VVId += MHDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Manipur"))
                VVId += MNDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Meghalaya"))
                VVId += MGDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Mizoram"))
                VVId += MZDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Nagaland"))
                VVId += NGDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Odisha"))
                VVId += ODDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Punjab"))
                VVId +=PJDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Rajasthan"))
                VVId += RJDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Sikkim"))
                VVId += SKDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Tamil Nadu"))
                VVId += TNDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Tripura"))
                VVId += TRDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Uttar Pradesh"))
                VVId += UPDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Uttarakhand"))
                VVId += UKDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("West Bengal"))
                VVId += WBDistrictCode(userDetailEntity.GetAddressDetail.District);
            else if (userDetailEntity.GetAddressDetail.State.Equals("Telangana"))
                VVId += TSDistrictCode(userDetailEntity.GetAddressDetail.District);
            else
                VVId += JKDistrictCode(userDetailEntity.GetAddressDetail.District);

            VVId += nameDecodeAadhar(userDetailEntity.UserName, Convert.ToString(userDetailEntity.AadharNumber));
            return VVId;


        }

        private string APDistrictCode(string district) //Andhra Pradesh
        {
            if (district.Equals("Guntur"))
                return "AP01";
            else
            if (district.Equals("Vishakapatnam"))
                return "AP02";
            else
                return "AP03";
        }
        private string KLDistrictCode(string district) //Kerala
        {
            if (district.Equals("Kannur"))
                return "KL04";
            else
            if (district.Equals("Kochi"))
                return "KL05";
            else
                return "KL06";
        }
        private string HPDistrictCode(string district) //Himachal Pradesh
        {
            if (district.Equals("Manali"))
                return "HP07";
            else
            if (district.Equals("Shimla"))
                return "HP08";
            else
                return "HP09";
        }
        private string JHDistrictCode(string district) //Jharkand
        {
            if (district.Equals("Ranchi"))
                return "JH10";
            else
            if (district.Equals("Dumka"))
                return "JH11";
            else
                return "JH12";
        }

        private string MPDistrictCode(string district) //Madhya Pradesh
        {
            if (district.Equals("Bhopal"))
                return "MP13";
            else
            if (district.Equals("Indore"))
                return "MP14";
            else
                return "MP15";
        }

        private string MHDistrictCode(string district) //Maharastra
        {
            if (district.Equals("Pune"))
                return "MH16";
            else
            if (district.Equals("Mumbai"))
                return "MH17";
            else
                return "MH18";
        }

        private string MNDistrictCode(string district) //Manipur
        {
            if (district.Equals("Imphal"))
                return "MN19";
            else
            if (district.Equals("Moreh"))
                return "MN20";
            else
                return "MN21";
        }
        private string MGDistrictCode(string district) //Meghalaya
        {
            if (district.Equals("Shillong"))
                return "MG22";
            else
            if (district.Equals("Jowai"))
                return "MG23";
            else
                return "MG24";
        }

        private string UKDistrictCode(string district) //Uttarakhand
        {
            if (district.Equals("Haridwar"))
                return "UK25";
            else
            if (district.Equals("Dehradun"))
                return "UK26";
            else
                return "UK27";
        }

        private string UPDistrictCode(string district) //Uttarpradesh
        {
            if (district.Equals("Moradabad"))
                return "UP28";
            else
            if (district.Equals("Bareilly"))
                return "UP29";
            else
                return "UP30";
        }

        private string ANDistrictCode(string district) //Arunachal Pradesh
        {
            if (district.Equals("Itanagar"))
                return "AN31";
            else
            if (district.Equals("Ziro"))
                return "AN32";
            else
                return "AN33";
        }

        private string ASDistrictCode(string district) //Assam
        {
            if (district.Equals("Guwahati"))
                return "AS34";
            else
            if (district.Equals("Dispur"))
                return "AS35";
            else
                return "AS36";
        }

        private string BIDistrictCode(string district) //Bihar
        {
            if (district.Equals("Patna"))
                return "BI37";
            else
            if (district.Equals("Gaya"))
                return "BI38";
            else
                return "BI39";
        }

        private string CHDistrictCode(string district) //chattisgarh
        {
            if (district.Equals("Raipur"))
                return "CH40";
            else
            if (district.Equals("Durg"))
                return "CH41";
            else
                return "CH42";
        }

        private string GODistrictCode(string district) //Goa
        {
            if (district.Equals("Panaji"))
                return "GO43";
            else
            if (district.Equals("Canacona"))
                return "GO44";
            else
                return "GO45";
        }

        private string GJDistrictCode(string district) //Gujarat
        {
            if (district.Equals("Surat"))
                return "GJ46";
            else
            if (district.Equals("Rajkot"))
                return "GJ47";
            else
                return "GJ48";
        }

        private string HYDistrictCode(string district) //Haryana
        {
            if (district.Equals("Panipat"))
                return "HY49";
            else
            if (district.Equals("Faridabad"))
                return "HY50";
            else
                return "HY51";
        }

        private string KNDistrictCode(string district) //Karnataka
        {
            if (district.Equals("Bangalore"))
                return "KN52";
            else
            if (district.Equals("Udipi"))
                return "KN53";
            else
                return "KN54";
        }

        private string MZDistrictCode(string district) //Mizoram
        {
            if (district.Equals("Aizwal"))
                return "MZ55";
            else
            if (district.Equals("Lunglei"))
                return "MZ56";
            else
                return "MZ57";
        }

        private string NGDistrictCode(string district) //Nagaland
        {
            if (district.Equals("Kohima"))
                return "NG58";
            else
            if (district.Equals("Dimapur"))
                return "NG59";
            else
                return "NG60";
        }

        private string ODDistrictCode(string district) //Odisha
        {
            if (district.Equals("Bhubaneswar"))
                return "OD61";
            else
            if (district.Equals("Puri"))
                return "OD62";
            else
                return "OD63";
        }

        private string PJDistrictCode(string district) //punjab
        {
            if (district.Equals("Amritsar"))
                return "PJ64";
            else
            if (district.Equals("Patiala"))
                return "PJ65";
            else
                return "PJ66";
        }

        private string RJDistrictCode(string district) //Rajasthan
        {
            if (district.Equals("Jaipur"))
                return "RJ67";
            else
            if (district.Equals("Kota"))
                return "RJ68";
            else
                return "RJ69";
        }

        private string TNDistrictCode(string district) //Tamil Nadu
        {
            if (district.Equals("Madhurai"))
                return "TN70";
            else
            if (district.Equals("Chennai"))
                return "TN71";
            else
                return "TN72";
        }

        private string SKDistrictCode(string district) //Sikkim
        {
            if (district.Equals("Gangtok"))
                return "SK73";
            else
            if (district.Equals("Mangan"))
                return "SK74";
            else
                return "SK75";
        }

        private string TSDistrictCode(string district) //Telangana
        {
            if (district.Equals("Hyderabad"))
                return "TS76";
            else
            if (district.Equals("Nirmal"))
                return "TS77";
            else
                return "TS78";
        }

        private string TRDistrictCode(string district) //Tripura
        {
            if (district.Equals("Agartala"))
                return "TR79";
            else
            if (district.Equals("Dharma-Nagar"))
                return "TR80";
            else
                return "TR81";
        }

        private string WBDistrictCode(string district) //West Bengal
        {
            if (district.Equals("Kolkata"))
                return "WB82";
            else
            if (district.Equals("Darjeling"))
                return "WB83";
            else
                return "WB84";
        }
        private string JKDistrictCode(string district) //Jammu Kashmir
        {
            if (district.Equals("Srinagar"))
                return "JK85";
            else
            if (district.Equals("Jammu"))
                return "JK86";
            else
                return "JK87";
        }

       
        private string nameDecodeAadhar(string UserName, string Aadhar)
        {
            string name = UserName.Substring(0, 4);
            byte[] encodeArray = System.Text.Encoding.ASCII.GetBytes(name);
            char[] vvid = new char[10];
            for (int j = 0; j < encodeArray.Length; j++)
            {
                int x = (int)(encodeArray[j] % 26);

                string z = Convert.ToString(x, toBase: 2);
                char y = (char)(x + 65);
                vvid[j] = y;

            }
            
            string decoded = vvid[3]+""+vvid[0] + Aadhar.Substring(8) + vvid[2]+""+vvid[1];

            return decoded;
        }
    }
}
