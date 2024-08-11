using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    public FruitNinjaGameManager GameManager;
    public List<GameObject> ObjectsToReset;

    //Main Panel
    public GameObject MainPanel;
    public TextMeshProUGUI MainText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI FruitsTotalCountText;

    //Mini Panel
    public GameObject StartPanel;
    public GameObject DetailsPanel;
    public List<TextMeshPro> FruitCountText;
    List<Vector3> StartPositions;
    List<Vector3> StartRotation;
    private void Start()
    {
        StartPositions = new List<Vector3>();
        StartRotation = new List<Vector3>();
        foreach (GameObject ob in ObjectsToReset)
        {
            StartPositions.Add(new Vector3(ob.transform.position.x, ob.transform.position.y, ob.transform.position.z));
            StartRotation.Add(new Vector3(ob.transform.eulerAngles.x, ob.transform.eulerAngles.y, ob.transform.eulerAngles.z));
        }
    }
    private void Update()
    {
        LivesText.text = GameManager.Lives.ToString();
        FruitsTotalCountText.text = GameManager.FruitsSliced.ToString();
        ScoreText.text = GameManager.Score.ToString();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetAllObjects()
    {
        for (int i=0;i< ObjectsToReset.Count;i++)
        {
            ObjectsToReset[i].GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            ObjectsToReset[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            ObjectsToReset[i].transform.position = StartPositions[i];
            ObjectsToReset[i].transform.eulerAngles = StartRotation[i];
        }
    }
    public void IncrementFruitText(string Name)
    {
        foreach(TextMeshPro tmp in FruitCountText)
        {
            if(tmp.name.Contains(Name))
            {
                int.TryParse(tmp.text, out int num);
                num++;
                tmp.text = num.ToString();
            }
        }
    }
    public void ResetFruitCountNumbers()
    {
        foreach (TextMeshPro tmp in FruitCountText)
        {
            tmp.text = "0";
        }
    }
}