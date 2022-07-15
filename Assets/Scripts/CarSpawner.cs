using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    public Transform playerTransfom;

    private float carDistance = 25f;
    private float way = 1.2f;
    private float way2 = -1.2f;
    private int carNumber;
    private int wayNumber;
    void Start()
    {
        InvokeRepeating("CloneCar", 3f, 2f);
    }
    
    private void CloneCar()
    {
        carNumber = Random.Range(0, cars.Count);

        wayNumber = Random.Range(0, 2);

        Vector3 carPos = new Vector3(wayNumber == 0 ? way : way2 , 0f, carDistance);

        carDistance = playerTransfom.position.z + 60f;

        Instantiate(cars[carNumber].gameObject, carPos, Quaternion.AngleAxis(180f, Vector3.down));

    }
  
}
