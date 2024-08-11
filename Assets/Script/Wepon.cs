using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public FruitNinjaGameManager GameManager;
    public UIScript UIScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Fruit>() != null && GameManager.GameStarted==true)
        {
            Fruit FruitScript = collision.gameObject.GetComponent<Fruit>();
            GameManager.AddScore(FruitScript.Points);
            FruitScript.Slice();
            if (FruitScript.name.Contains("Bomb"))
            {
                GameManager.DecreaseLife();
            }
            else
            {
                UIScript.IncrementFruitText(FruitScript.name);
            }
        }
    }
}
