using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int Points = 50;
    public string Name;
    public GameObject SlicedFruit;
   
 public void Slice()
    {
        GameObject slicedObject = Instantiate(SlicedFruit, this.transform.position, Quaternion.identity);
        Destroy(slicedObject, 3);
        Destroy(this.gameObject);
    }
}