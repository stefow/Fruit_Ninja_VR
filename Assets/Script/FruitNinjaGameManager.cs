using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitNinjaGameManager : MonoBehaviour
{
    public FruitSpawner Spawnder;
    public UIScript UIScript;
    public int Score=0;
    public int Lives = 3;
    public int FruitsSliced = 0;
    public bool GameStarted = false;

    float totalTime=4;
    void Update()
    {
        if (GameStarted)
        {
            if (totalTime >= 0)
            {
                totalTime -= Time.deltaTime;
                if (totalTime > 1)
                {
                    UIScript.MainText.text = ((int)totalTime).ToString();
                }
                else
                {
                    UIScript.MainText.text = "SLICE";
                }
            }
        }
    }
    public void DecreaseLife()
    {
        Lives--;
        if (Lives==0)
        {
            StopFruitNinja();
            UIScript.MainText.text = "Game over";
        }
    }
    public void AddScore(int points)
    {
        if(points>0) FruitsSliced++;
        Score += points;
    }     
    public void StartFruitNinja()
    {
        Spawnder.StartSpawning();
        UIScript.MainPanel.SetActive(true);
        UIScript.StartPanel.SetActive(false);
        UIScript.DetailsPanel.SetActive(true);
        Score = 0;
        totalTime = 4;
        FruitsSliced = 0;
        Lives = 3;
        UIScript.LivesText.text = Lives.ToString();
        UIScript.ScoreText.text = FruitsSliced.ToString();
        GameStarted = true;
    }
    public void StopFruitNinja()
    {
        Spawnder.StopSpawning();
        UIScript.StartPanel.SetActive(true);
        UIScript.DetailsPanel.SetActive(false);
        UIScript.ResetFruitCountNumbers();
        GameStarted =false;
        UIScript.MainText.text = "";
    }
}
