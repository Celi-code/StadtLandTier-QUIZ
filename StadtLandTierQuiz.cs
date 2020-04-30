using System;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablendeklaration
            string[] arraycategories = { "Tier", "Land", "Stadt" };
            string[,] arraywords = { { "Esel", "Hase", "Hund", "Katze", "Maus", "Pferd", "Vogel", "Fisch", "Wolf", "Tiger"},
                                                      { "Kroatien", "Italien", "Brasilien", "Frankreich", " Griechenland", "Peru", "Polen", "China", "Japan", "Vietnam" },
                                                      { "Rom", "Zagreb", "Chicago", "Tokyo", "Kyoto", "Hongkong", "Paris", "London", "Moskau", "Athen" } };
            Random random = new Random();
            string instantChoice;
            int choice;
            string word;
            int found;
            string lifes = "+++++";
            int lifescount = 0;
            bool isChoiceRight = true;

            do
            {   
                if (isChoiceRight == false)
                    Console.WriteLine("Geben Sie die Zahl 1, 2 oder 3 ein um zwischen den Kategorien 1.TIER, 2.LAND, 3.STADT zu wählen."); //Erscheint nur bei Wiederholung der Eingabe
                //Startanzeige
                Console.WriteLine("TIER-LAND-STADT QUIZ");
                Console.WriteLine();
                Console.Write($"Wählen Sie eine der folgenden Kategorien aus: \n1.TIER \n2.LAND \n3.STADT \nAuswahl: ");
                instantChoice = Console.ReadLine();
                isChoiceRight = false;
            } while (instantChoice != "1" && instantChoice != "2" && instantChoice != "3"); //Fehlerabfrage

            isChoiceRight = true; // Startwert
            choice = Convert.ToInt32(instantChoice);
            Console.WriteLine();
            word = arraywords[choice - 1, random.Next(1, arraywords.GetLength(1))]; //Randomwort wird erstellt
            int letters = word.Length;
            string category = arraycategories[choice - 1];

            char[] b = word.ToCharArray();

            string underline = "_";
            found = 0;
            bool hit = false;

            Console.WriteLine(category + " mit " + letters + " Buchstaben und dem Anfangsbuchstaben " + b[0]);
            Console.WriteLine();

            //String mit Unterstrichen in der Anzahl des Wortes wird erstellt
            for (int k = 2; k < letters; k++)
           
                underline += "_";

            char[] allletters = new char[b.Length];
            bool isredundand = false;
            char l;

            do 
            {
                do
                {
                    //Anzeige
                    Console.Write($"Wort: " + b[0] + underline);
                    Console.Write($"           Leben: " + lifes + $"\n");
                    Console.Write("Buchstaben drücken: ");
                    l = Console.ReadKey().KeyChar; //Einlesen des eingegebenen Buchstaben
                    Console.Write("\n");

                    foreach (char t in allletters)
                    {
                        if (t == l)
                        {
                            isredundand = true;
                            break;
                        }
                        else
                        {
                            isredundand = false;
                            continue;
                        }
                            
                    }

                } while (isredundand == true);
               
                             
                //Vergleich des eingelesen Buchstaben mit den Buchstaben des Wortes
                for (int i = 0; i < b.Length; i++)
                {
                    if (l == b[i]) //wenn der eingegebene Buchstabe an irgendeiner Stelle im Wort gefunden wurde
                    {
                        allletters[i] = l;
                        found++;
                        letters = word.Length - found - 1; //bei gefunden Buchstaben wird die Anzahl der noch zu erratenden Buchstaben kleiner
                        underline = underline.ToString().Remove(i - 1, 1).Insert(i - 1, l.ToString()); //Die Unterstriche werden durch den gefunden Buchstaben ersetzt
                        hit = true;
                    }
                    else
                        continue; //wird für jeden Buchstaben des Wortes gemacht
                }
                if (found == word.Length - 1)
                {
                    Console.WriteLine();
                    Console.Write($"Wort: " + b[0] + underline);
                    Console.Write($"           Leben: " + lifes + $"\n");
                    Console.WriteLine("*** Gratuliere, Sie haben gewonnen! ***");
                    break; //Gewonnen! Schleife wird abgebrochen
                }
                else if (hit == false) //Wenn es keine Übereinstimmung gab ist der boolean-Wert false
                {
                    Console.WriteLine("Daneben - ein Leben verloren!");
                    lifes = lifes.Remove(lifescount, 1).Insert(lifescount, "-"); //Es wird ein Leben abgezogen und durch '-' ersetzt
                    lifescount++; //Leben werden gezählt
                }
                else 
                {
                    Console.WriteLine($"Treffer, nur noch {letters} zu erraten.");
                    hit = false; 
                }
                Console.WriteLine();

            } while (lifescount < 5); //solange bis alle Leben weg sind

            if (lifescount == 5)
                Console.WriteLine($"Verloren! Das richtige Wort war {word}"); //verloren, Spiel beendet
        } 
    }
}
