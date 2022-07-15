using UnityEngine;
public class RoadSpawner : MonoBehaviour
{
    public GameObject Road;
    public Transform playerTransfom;

    private float roadDistance = 6f;
    void Start()
    {
        InvokeRepeating("RoadClone", .2f, .2f);
    }
    private void RoadClone()
    {
        Vector3 roadPos = new Vector3(0f, 0f, roadDistance);

        roadDistance = roadDistance + 6f;

        Instantiate(Road, roadPos, Quaternion.AngleAxis(90f, Vector3.up));
    }

}
