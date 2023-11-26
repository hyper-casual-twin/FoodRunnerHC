using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeed : MonoBehaviour
{
    public enum CarTypes
    {
        taxi,
        police,
        otobus,
        standart
    }

    public CarTypes carTypes;

    private float taxiSpeed = 12f;
    private float policeSpeed = 15f;
    private float otobusSpeed = 10f;
    private float standartSpeed = 11f;

    void Update()
    {
        if (CarTypes.taxi == carTypes)
        {
            this.transform.position += new Vector3(0, 0, -taxiSpeed * Time.deltaTime);
        }
        else if (carTypes == CarTypes.police)
        {
            this.transform.position += new Vector3(0, 0, -policeSpeed * Time.deltaTime);
        }
        else if (CarTypes.otobus == carTypes)
        {
            this.transform.position += new Vector3(0, 0f, -otobusSpeed * Time.deltaTime);
        }
        else if (CarTypes.standart == carTypes)
        {
            this.transform.position += new Vector3(0, 0, -standartSpeed * Time.deltaTime);
        }
    }

}
