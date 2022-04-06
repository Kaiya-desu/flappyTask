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

    private static string filePath = @"save.txt";

    public static void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("laduje plik txt");
            topRanking = File.ReadAllLines(filePath).Select(x => Convert.ToInt32(x)).ToList();
        }
        else
        {
            Debug.Log("brak plik txt");
            topRanking = new List<int> { 0, 0, 0, 0, 0 };
        }
       
    }

    public static bool checkTop(int newScore)
    {
        // sprawdzamy czy nowy rekord jest wyzszy od 4 indexu (tj pozycji na samym dole top rankingu),
        // nastepnie sortujemy wszystkie rekordy i odwracmay je by byly malejaco
        Debug.Log("jestem w check top! " + newScore);
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
        // zapisujemy nowa liste rekordow
        Debug.Log(topRanking);
        if (!File.Exists(filePath))
        {
            File.Create(filePath); // tworzymy nowy plik
           // File.WriteAllLines(filePath, topRanking.Select(x => x.ToString()));
        }
    //    File.WriteAllLines(filePath, topRanking.Select(x => x.ToString()));
    }

    // metoda ktora podaje statystyki do rankingu
    public static List<int> GetRanking()
    {
        return topRanking;
    }

}
