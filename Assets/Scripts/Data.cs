using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static int score = 0;
    public static int level = 0;
    public static string time = "00:00:00";
    public static int consecutiveRow = 0;
    public static int currentExp = 0;
    public static int maxExp = 10;

    void Start() {
        score = 0;
        level = 0;
        time = "00:00:00";
        consecutiveRow = 0;
        currentExp = 0;
        maxExp = 10;
    }

    void Update()
    {
        time = ConvertTime((int) Time.timeSinceLevelLoad);

        if(currentExp == maxExp) IncreaseLevel();
    }

    public static void AddScore()
    {
        score += CalculateScore();
    }
    

    private static int CalculateScore()
    {
        currentExp += consecutiveRow;

        switch (consecutiveRow)
        {
            case 1:
                consecutiveRow = 0;
                return 40 * (level + 1);
            case 2:
                consecutiveRow = 0;
                return 100 * (level + 1);
            case 3:
                consecutiveRow = 0;
                return 300 * (level + 1);
            case 4:
                consecutiveRow = 0;
                return 1200 * (level + 1);
            default:
                consecutiveRow = 0;
                return 0;
        }
    }

    private string ConvertTime(int time)
    {
        int seconds = time % 60;
        time = time / 60;
        int minutes = time % 60;
        time = time / 60;
        int hours = time % 60;
        return (hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00")); 
    }
    
    private void IncreaseLevel()
    {
        level++;
        int firstFormula = level * 10 + 10;
        int secondFormula = Math.Max(100, level * 10 - 50);

        if(firstFormula < secondFormula) maxExp = firstFormula;
        if(firstFormula >= secondFormula) maxExp = secondFormula;

        currentExp = 0;
    }
}
