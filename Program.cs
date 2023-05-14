using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace SlutprojektNy
{

    class Program
    {
        static void Main(string[] args)
        {
            // Skapa en lista av bilar
            List<Bil> bilar = new List<Bil>
        {
            
            new NyBil("Honda", "Civic", 2022, 20000.00),
            new NyBil("Toyota", "Corolla", 2022, 22000.00),
            new AnvändBil("Ford", "Mustang", 2018, 25000.00, 5000),
            new AnvändBil("Chevrolet", "Camaro", 2015, 18000.00, 80000),
            new AnvändBil("Tesla", "Model S", 2016, 35000.00, 30000),
            new LyxBil("Lamborghini", "Aventador", 2022, 23000000.00,10),
            new LyxBil("Koenigsegg", "Jesko", 2020, 40000000, 2),
        };
        // Skapar en tom lista för användarens köpta bilar
            List<Bil> KöptaBilar = new List<Bil>();


            Console.WriteLine("Välkommen till Bli Butiken!");

            while (true)
            {
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("1. Titta på alla bilar som säljs");
                Console.WriteLine("2. Köpa en bil");
                Console.WriteLine("3. Dina köpta bilar");
                Console.WriteLine("4. Borde du ha vinterdäck? Gör en väder koll");
                Console.WriteLine("5. Lämna");

                string svar = Console.ReadLine();

///  En switch som tar ditt svar och kollar om de är 1,2,3,4 eller 5. 
/// Detta är så att användaren inte ska kunna skriva något annat. Efter som att Deaufalten
/// skickar  ett svar till användaren att svaret är ogiltigt

                switch (svar)
                {

                    case "1":
                        Console.WriteLine("Bilar som säljs:");
                        foreach (Bil bil in bilar)
                        {
                            // Om bilen inte är såld, skriv ut den
                            if (!bil.ärSåld)
                            {
                                Console.WriteLine(bil);
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Vilken bil vill du köpa? Skriv nummret på den bil du vill köpa:");
                        /// En for-loop som har samma funktion som en valig
                        /// foreach, men jag använder en for-loop så att jag kan 
                        /// Använda mig av [i], så att det är enklare att skriva ut 
                        /// och använda bil listan som skrivs ut
                        for (int i = 0; i < bilar.Count; i++)
                        {
                            if (!bilar[i].ärSåld)
                            {

                                Console.WriteLine($"{i + 1}. {bilar[i]}");
                            }
                        }
/// <summary>
/// Det under är en try-catch så att programmet inte crashar om använderen skriver något 
/// den inte borde. För om int.Parse misslyckas, så fångas det av catchen som ger ut ett felmedelande
/// </summary>

                        int bilVal;
                        try
                        {
                            bilVal = int.Parse(Console.ReadLine());
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Ogiltigt val. Vänligen skriv in numret på bilen du vill köpa.");
                            continue; // Fortsätter till nästa del av loopen
                        }

// Om man svarar ett för högt, för lågt eller ett nummer på en bil som redan är såld. 
                        if (bilVal < 1 || bilVal > bilar.Count || bilar[bilVal - 1].ärSåld)
                        {
                            Console.WriteLine("Ogiltigt val. Vänligen skriv in numret på en osåld bil.");
                            continue;
                        }


// Måste göra så här efter som att for börjar räkna på 0
                        Bil köptBil = bilar[bilVal - 1];
                        köptBil.Såld();
                        KöptaBilar.Add(köptBil);


                        Console.WriteLine($"Grattis, du äger nu en: {köptBil}.");
                        break;

                    case "3":
                        Console.WriteLine("Här är dina köpta bilar:");

                        if (KöptaBilar.Count == 0)
                        {
                            Console.WriteLine("Du har inte köpt några bilar");
                        }

                        else
                        {
                            foreach (Bil bil in KöptaBilar)
                            {
                                Console.WriteLine(bil);
                            }
                        }

                        break;

                    case "4":

                        WebClient client = new WebClient();
                        Console.WriteLine("Vilken stad är du i?");
                        try
                        {
                            string stad = Console.ReadLine();

                            string apiNyckel = "5165b779e353f1d3e2b2f9898834424c";


                            // Hämta JSON från webben
                            string url = $"http://api.openweathermap.org/data/2.5/weather?q={stad}&units=metric&appid={apiNyckel}";
                            string json = client.DownloadString(url);

                            // Skapa objektet som skall lagra JSON-data

                            VäderApp.Prognos VäderData = JsonSerializer.Deserialize<VäderApp.Prognos>(json);

                            if (VäderData.main.temp < 0)
                            {
                                Console.WriteLine($"På grund av att det är {VäderData.main.temp.ToString()} grader där du är så borde du ha vinterdäck");
                            }
                            else
                            {
                                Console.WriteLine($"Nej, eftersom att det är {VäderData.main.temp.ToString()} grader så behöver du inte vinterdäck");
                            }
                            break;

                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Ogiltig stad");
                            continue;
                        }

                    case "5":
                        Console.WriteLine("Tack för att du handlat hoss oss. Hej då!");
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
        }
    }
}

