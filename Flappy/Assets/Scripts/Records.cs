using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class Records
{
    // odtwarza statyczna liste top 5 rekordow 
    // po grze sprawdza czy nowy wynik jest lepszy -> nadpisuje plik, 

    private static List<int> topRanking;

    // nie wiem jaka jest sciezka na emulatorze BlueStacks na ktorym probowalam testowac aplikacje (nie mam telefonu z androidem)
    // tak wiec nie wiem czy sciezka Application.persistentDataPath + "/save.txt" dziala.....
    private static string filePath = "save.txt"; // na komputerze -> @"save.txt"; dla androida -> Application.persistentDataPath + "/save.txt";

    public static void LoadFromFile()
    {
        Debug.Log(new FileInfo(filePath).Length);
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 14) // plik z 5x 0 ma dlugosc 15 wiec sprawdzam czy na pewno sa potrzebne dane w pliku
        {
            Debug.Log("laduje plik txt");
            topRanking = File.ReadAllLines(filePath).Select(x => Convert.ToInt32(x)).ToList();
        }
        else
        {
            Debug.Log("brak plik txt");
            topRanking = new List<int> {0,0,0,0,0};
        }
       
    }

    public static bool checkTop(int newScore)
    {
        // sprawdzamy czy nowy rekord jest wyzszy od 4 indexu (tj pozycji na samym dole top rankingu),
        // nastepnie sortujemy wszystkie rekordy i odwracmay je by byly malejaco
        if (newScore > topRanking[4])
        {
            Debug.Log("wynik wiekszy od 5 pozycji");
            topRanking[4] = newScore;
            topRanking.Sort();
            topRanking.Reverse();
            SaveToFile();

            return true;
        }
        return false;  // gdy nowy wynik jest nizszy niz top 5
    }

    static void SaveToFile()
    { 
        // zapisujemy liste rekordow
        if (!File.Exists(filePath))
        {
             File.Create(filePath); // tworzymy nowy plik jezeli nie istnieje
        }
        File.WriteAllLines(filePath, topRanking.Select(x => string.Join(",", x)));
    }

    // metoda ktora podaje statystyki do rankingu
    public static string GetRanking()
    {
        return string.Join("\n", topRanking.ToArray());

    }

}
