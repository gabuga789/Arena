using System;

namespace Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // === HELDENPROFIL EINLESEN ===
            Console.WriteLine("=== HELDEN-ERSTELLUNG ===");
            Console.Write("Wie heißt dein Held? ");
            string heldenName = Console.ReadLine();

            Console.Write("Lebenspunkte: ");
            int lebenspunkte = int.Parse(Console.ReadLine());

            Console.Write("Stärke: ");
            int staerke = int.Parse(Console.ReadLine());

            Console.Write("Gold: ");
            int gold = int.Parse(Console.ReadLine());

            Console.Write("Kritische Chance: ");
            double kritischeChance = double.Parse(Console.ReadLine());

            // Absicherung der kritischen Chance
            if (kritischeChance > 1 || kritischeChance<0)
            {
                Console.WriteLine(" Die Chance muss zwischen 0 und 1 liegen - sie wird auf 0 gesetzt.");
                kritischeChance = 0;
            }

            bool hatSchild = true;

            // Statusmeldung basierend auf den Lebenspunkten ausgeben
            if (lebenspunkte < 20)
            {
                Console.WriteLine("Kritisch! Nimm einen Heiltrank.");
            }
            else if (lebenspunkte < 60)
            {
                Console.WriteLine("Angeschlagen.");
            }
            else
            {
                Console.WriteLine("Alles im grünen Bereich.");
            }


            // === GEGNER und WAFFE ===
            Console.WriteLine();
            Console.WriteLine("=== GEGNER und AUSRÜSTUNG ===");

            // Feste Werte für den Gegner (aus den Aufgabenstellungen)
            string gegnerName = "Goblin";
            int gegnerLebenspunkte = 60;
            int gegnerRuestung = 8;

            Console.WriteLine($"Dein Gegner: {gegnerName} (LP: {gegnerLebenspunkte}, Rüstung: {gegnerRuestung})");

            // Waffenauswahl per Switch-Case
            Console.Write("Waffe (Schwert/Axt/Bogen): ");
            string waffenName = Console.ReadLine();
            int waffenBonus;

            switch (waffenName)
            {
                case "Schwert":
                    waffenBonus = 4;
                    break;
                case "Axt":
                    waffenBonus = 10;
                    break;
                case "Bogen":
                    waffenBonus = 1;
                    break;
                default:
                    Console.WriteLine("Unbekannte Waffe - du kämpfst mit Fäusten.");
                    waffenName = "bloßen Fäusten";
                    waffenBonus = 0;
                    break;
            }

            int grundschaden = 10;


            // === SCHADENSBERECHNUNG ===
            Console.WriteLine();
            Console.WriteLine("=== KAMPF ===");

            // Schadensformel: (Grundschaden + Bonus) * Stärke - Rüstung
            int schaden = (grundschaden + waffenBonus) * staerke - gegnerRuestung;
            Console.WriteLine($"{heldenName} greift mit {waffenName} an und verursacht {schaden} Schaden.");

            // Reicht ein Schlag?
            if (schaden >= gegnerLebenspunkte)
            {
                Console.WriteLine($"{gegnerName} fällt mit einem Schlag!");
            }
            else
            {
                Console.WriteLine($"{gegnerName} übersteht den ersten Angriff.");
            }

            // wer ist im vorteil
            int vorsprung = lebenspunkte - gegnerLebenspunkte;
            if (vorsprung > 0)
            {
                Console.WriteLine($"{heldenName} ist um {vorsprung} LP im Vorteil.");
            }
            else if (vorsprung < 0)
            {
                Console.WriteLine($"{gegnerName} ist um {-vorsprung} LP im Vorteil.");
            }
            else
            {
                Console.WriteLine("Gleichstand.");
            }


            // === KAMPFBILANZ ===
            Console.WriteLine();
            Console.WriteLine("=== KAMPFBILANZ ===");
            Console.Write("Bestrittene Kämpfe: ");
            int kaempfe = int.Parse(Console.ReadLine());

            Console.Write("Davon gewonnen: ");
            int siege = int.Parse(Console.ReadLine());

            if (kaempfe <= 0 || siege<kaempfe)
            {
                Console.WriteLine(" Unsinnige Eingabe - die Bilanz kann nicht berechnet werden.");
            }
            else
            {
                int niederlagen = kaempfe - siege;
                double siegquote = (double)siege / kaempfe;

                Console.WriteLine($"Siege:       {siege}");
                Console.WriteLine($"Niederlagen: {niederlagen}");
                Console.WriteLine($"Siegquote:   {siegquote:F2}");

                // Rang ermitteln
                char rang;
                if (siegquote >= 0.75)
                {
                    rang = 'A';
                }
                else if (siegquote >= 0.50)
                {
                    rang = 'B';
                }
                else if (siegquote >= 0.25)
                {
                    rang = 'C';
                }
                else
                {
                    rang = 'D';
                }

                Console.WriteLine($"Rang:        {rang}");

                // Titel über Switch-Case zuweisen
                switch (rang)
                {
                    case 'A':
                        Console.WriteLine("Titel:       Legende der Arena");
                        break;
                    case 'B':
                        Console.WriteLine("Titel:       Erfahrener Kämpfer");
                        break;
                    case 'C':
                        Console.WriteLine("Titel:       Solider Anfänger");
                        break;
                    default:
                        Console.WriteLine("Titel:       Noch viel zu lernen");
                        break;
                }

                // Bonus für Rang A
                if (rang == 'A')
                {
                    Console.WriteLine("Bosskampf freigeschaltet!");
                }
            }


            // === HÄNDLER ===
            Console.WriteLine();
            Console.WriteLine("=== HÄNDLER ===");
            Console.Write("Preis für einen Heiltrank: ");
            int trankPreis = int.Parse(Console.ReadLine());

            if (trankPreis <= 0)
            {
                Console.WriteLine("Der Preis muss größer als 0 sein.");
            }
            else
            {
                int traenke = gold / trankPreis;
                int restGold = gold % trankPreis;
                Console.WriteLine($"Du kannst {traenke} Tränke kaufen, {restGold} Gold bleiben übrig.");
            }
        }
    }
}
