using Newtonsoft.Json;
using PlantLookUp.data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantLookUp
{
    class Program : Methods
    {
        static async Task Main(string[] args)
        {
            //Config The Bot
            string ApiToken = ""; // Put Your Api Token Here
            DataHandle dh = new DataHandle(ApiToken);
            string address = "0x5Ab19e7091dD208F352F8E727B6DCC6F8aBB6275";
            string topic = "0x393ccba6479926a7c4a6471a3b4584229e2df48a1858c8caf57680927dced5ff";
            double fromBlock = 8974488; // Give The Block You Want Strat Track There ( First Block On PVU : 8974488 )
            int toBlock = 999999999; // The Last Block You Want ( No Need To Change It Gives You The First 1000 One) 

            //Run
            Console.WriteLine("Getting Data...");
            string[] LastBlockDetails = (await SaveTheDataAsync(dh, address, topic, fromBlock, toBlock)).Split(',');
            Console.WriteLine("Done...! \n Mint Reacord Saved This Time: " + LastBlockDetails[0] + "\n last Block Number :" + LastBlockDetails[1] + "\n Last Block Time :" + LastBlockDetails[2] + "\n Exit? { e / E } || Continue: { Enter }");
            string Exit = Console.ReadLine();
            while (Exit != "e" || Exit != "E")
            {
                Console.WriteLine("Waiting 5 Sec...");
                Thread.Sleep(5000);
                Console.WriteLine("Getting Data...");
                fromBlock = double.Parse(LastBlockDetails[1]);
                LastBlockDetails = (await SaveTheDataAsync(dh, address, topic, fromBlock, toBlock)).Split(',');
                Console.WriteLine("Done...! \n Mint Reacord Saved This Time: " + LastBlockDetails[0] + "\n last Block Number :" + LastBlockDetails[1] + "\n Last Block Time :" + LastBlockDetails[2] + "\n Exit: { e / E } || Continue: { Enter }");
                Exit = Console.ReadLine();
            }
        }

        private static async Task<string> SaveTheDataAsync(DataHandle dh, string address, string topic, double fromBlock, int toBlock)
        {
            var s = await dh.GetData(address, topic, fromBlock, toBlock);
            List<PlantTableModel> plants = new List<PlantTableModel>();
            foreach (var item in s)
            {
                PlantTableModel PM = new PlantTableModel()
                {
                    Adrress = ExtractWalletAddress(item.Data),
                    BlockNumber = HexToDec(item.BlockNumber),
                    MintTime = UnixTimeStampToDateTime(HexToDec(item.TimeStamp)),
                    PlantID = HexToDec(ExtractPlantIdHex(item.Data)),
                };
                PlantAtt plantAtt = Methods.GetPlant(PM.PlantID);
                PM.PlantKind = plantAtt.IsMotherTree;
                PM.PlantRace = plantAtt.Race;
                PM.PlantRarity = plantAtt.Rarity;
                PM.PlantCycle = plantAtt.Cycle;
                PM.PlantBaseLE = plantAtt.BaseLE;
                plants.Add(PM);
            }
            Console.WriteLine("Saving Data...");
            using (var db = new PlantContext())
            {
                foreach (var item in plants)
                {
                    db.Plants.Add(item);
                }
                db.SaveChanges();
            }
            int Count = plants.Count;
            return $"{Count}," + $"{plants[Count - 1].BlockNumber}," + $"{plants[Count - 1].MintTime}";
        }
    }
}
