using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public List<GameObject> fruits = new List<GameObject>();
    private List<GameObject> deListCars = new List<GameObject>();
    public Transform playerTransfom;

    private float fruitDistance = 25f;
    private float way = 1.2f;
    private float way2 = -1.2f;
    private int fruitNumber;
    private int wayNumber;
    void Start()
    {
        InvokeRepeating("CloneFruit", 3f, 3f);
    }

    private void CloneFruit()
    {
        fruitNumber = Random.Range(0, fruits.Count);

        wayNumber = Random.Range(0, 2);

        Vector3 fruitPos = new Vector3(wayNumber == 0 ? way : way2, .4f, fruitDistance);

        fruitDistance = playerTransfom.position.z + 100f;

        Instantiate(fruits[fruitNumber].gameObject, fruitPos, Quaternion.AngleAxis(180f, Vector3.down));

        deListCars.Add(fruits[fruitNumber]);

    }
}
