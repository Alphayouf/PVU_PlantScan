using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantLookUp
{
    class PlantAtt
    {
        public bool IsMotherTree { get; set; }
        public int Rarity { get; set; }
        public string Race { get; set; }
        public int Cycle { get; set; }
        public int BaseLE { get; set; }
    }
    class Methods
    {
        public static PlantAtt GetPlant(int PlantId)
        {
            string PlantIdSt = PlantId.ToString();
            PlantAtt plant = new PlantAtt();
            //**************************Kind
            if (PlantIdSt[0] == '2')
            {
                plant.IsMotherTree = true;
            }
            else
            {
                plant.IsMotherTree = false;
            }
            //**************************Rarity
            int RarityTag = Int32.Parse(PlantIdSt[6].ToString() + PlantIdSt[7].ToString());
            if (RarityTag <= 59)
            {
                plant.Rarity = 1;
            }
            else if (RarityTag >= 60 && RarityTag <= 88)
            {
                plant.Rarity = 2;
            }
            else if (RarityTag >= 89 && RarityTag <= 98)
            {
                plant.Rarity = 3;
            }
            else
            {
                plant.Rarity = 4;
            }
            //**************************Else
            string RaceTag = PlantIdSt[3].ToString() + PlantIdSt[4].ToString();
            string Result = null;
            switch (RaceTag)
            {
                case "00":
                    Result = "Fire,48,400,500,600,800";
                    break;
                case "01":
                    Result = "Fire,48,400,500,600,800";
                    break;
                case "02":
                    Result = "Ice,60,500,610,680,850";
                    break;
                case "03":
                    Result = "Electro,60,500,610,680,850";
                    break;
                case "04":
                    Result = "Water,108,950,1100,1200,1400";
                    break;
                case "05":
                    Result = "Water,108,950,1100,1200,1400";
                    break;
                case "06":
                    Result = "Ice,60,500,610,680,850";
                    break;
                case "07":
                    Result = "Fire,48,400,500,600,800";
                    break;
                case "08":
                    Result = "Electro,48,500,610,680,850";
                    break;
                case "09":
                    Result = "Wind,72,750,860,950,1150";
                    break;
                case "10":
                    Result = "Wind,72,750,860,950,1150";
                    break;
                case "11":
                    Result = "Parasite,120,900,1010,1010,1250";
                    break;
                case "12":
                    Result = "Parasite,120,900,1010,1010,1250";
                    break;
                case "13":
                    Result = "Parasite,120,900,1010,1010,1250";
                    break;
                case "14":
                    Result = "Dark,192,1200,1900,2300,2500";
                    break;
                case "15":
                    Result = "Electro,48,500,610,680,850";
                    break;
                case "16":
                    Result = "Wind,96,900,1010,1100,1250";
                    break;
                case "17":
                    Result = "Fire,72,650,760,900,1100";
                    break;
                case "18":
                    Result = "Light,240,1200,1310,1400,1500";
                    break;
                case "19":
                    Result = "Light,240,1200,1310,1400,1500";
                    break;
                case "20":
                    Result = "Light,312,1600,1710,1800,2000";
                    break;
                case "21":
                    Result = "Light,312,1600,1710,1800,2000";
                    break;
                case "22":
                    Result = "Parasite,168,1300,1410,1500,1650";
                    break;
                case "23":
                    Result = "Parasite,168,1300,1410,1500,1650";
                    break;
                case "24":
                    Result = "Parasite,168,1300,1410,1500,1650";
                    break;
                case "25":
                    Result = "Metal,336,3500,4300,4800,5200";
                    break;
                case "26":
                    Result = "Metal,336,3500,4300,4800,5200";
                    break;
                case "27":
                    Result = "Metal,480,5500,6400,6800,7100";
                    break;
                case "28":
                    Result = "Metal,480,5500,6400,6800,7100";
                    break;
                case "29":
                    Result = "Ice,96,800,910,1000,1250";
                    break;
                case "30":
                    Result = "Fire,72,650,760,900,1100";
                    break;
                case "31":
                    Result = "Dark,192,1200,1900,2300,2500";
                    break;
                case "32":
                    Result = "Electro,60,650,760,900,1100";
                    break;
                case "33":
                    Result = "Dark,216,1400,2100,2500,2800";
                    break;
                case "34":
                    Result = "Electro,60,650,760,900,1100";
                    break;
                case "35":
                    Result = "Dark,216,1400,2100,2500,2800";
                    break;
                case "36":
                    Result = "Water,108,950,1100,1200,1400";
                    break;
                case "37":
                    Result = "Wind,98,900,1010,1100,1250";
                    break;
                case "38":
                    Result = "Water,120,1050,1200,1300,1500";
                    break;
                case "39":
                    Result = "Water,120,1050,1200,1300,1500";
                    break;
                case "90":
                    Result = "Fire,48,750,1100,1300,1500";
                    break;
                case "91":
                    Result = "Light,240,1400,1750,1940,2120";
                    break;
                case "92":
                    Result = "Ice,96,1050,1400,1600,1800";
                    break;
                case "93":
                    Result = "Dark,216,2800,2950,3100,3300";
                    break;
                default:
                    Result = "NotDefined,000,000,000,000,000";
                    break;
            }
            string[] array = Result.Split(',');
            plant.Race = array[0];
            plant.Cycle = Int32.Parse(array[1]);
            switch (plant.Rarity)
            {
                case 1:
                    plant.BaseLE = Int32.Parse(array[2]);
                    break;
                case 2:
                    plant.BaseLE = Int32.Parse(array[3]);
                    break;
                case 3:
                    plant.BaseLE = Int32.Parse(array[4]);
                    break;
                case 4:
                    plant.BaseLE = Int32.Parse(array[5]);
                    break;
            }
            return plant;
        }
        public static int HexToDec(string Hex)
        {
            return Convert.ToInt32(Hex, 16);
        }
        public static DateTime UnixTimeStampToDateTime(int dec)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(dec);
            return dtDateTime;
        }
        public static string ExtractWalletAddress(string Data)
        {
            char[] chars = Data.ToCharArray();
            string Address = null;
            for (int i = 0; i < 67 ; i++)
            {
                if (i > 25 && i < 66)
                {
                    Address += chars[i];
                }
            }
            return Address;
        }
        public static string ExtractPlantIdHex(string Data)
        {
            char[] chars = Data.ToCharArray();
            string PlantIdHex = null;
            for (int i = 184; i < Data.Length; i++)
            {
                if (i > 185 && i < Data.Length)
                {
                    PlantIdHex += chars[i];
                }
            }
            return PlantIdHex;
        }
    }



}
