using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FruitSpawner : MonoBehaviour
{
    public List<Transform> SpawnPoint;
    public List<GameObject> Fruits;
    public Vector3 force;
    private IEnumerator SpawnFruit(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            var rand = new System.Random();
            int NumberOfFruits = rand.Next(2, 5);
            for (int i = 0; i < NumberOfFruits; i++)
            {
                int index = rand.Next(0, Fruits.Count);
                GameObject fruit = Instantiate(Fruits[index], SpawnPoint[i].position, Quaternion.identity);
                fruit.name = Fruits[index].name;
                Rigidbody rb = fruit.GetComponent<Rigidbody>();
                rb.AddForce(force+new Vector3(Random.Range(0f, 0.1f), Random.Range(0f, 0.3f), Random.Range(0f, 0.1f)), ForceMode.Impulse);
                rb.AddTorque(new Vector3(Random.Range(2f, 6f), Random.Range(2f, 6f), Random.Range(2f, 6f)), ForceMode.Impulse);
                Destroy(fruit, 4);
            }
        }
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnFruit(4));
    }
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
