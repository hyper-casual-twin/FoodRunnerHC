using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private CharacterController controller;

    private Vector3 VerticalTargetPosition;
    private Vector3 forwardMove = Vector3.zero;
    private float currentLane = 1.3f;
    private float sideSpeed = 3.0f;

    public float forwardSpeed = 1.3f;
    public static PlayerMovement Instance;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        VerticalTargetPosition = new Vector3((currentLane), 0, 0);
        forwardSpeed = 1.3f;
    }

    void Update()
    {
        if (MobileInput.Instance.SwipeLeft || Input.GetKey(KeyCode.A))
            VerticalTargetPosition = new Vector3((-currentLane), 0, 0);

        if (MobileInput.Instance.SwipeRight || Input.GetKey(KeyCode.D))
            VerticalTargetPosition = new Vector3((currentLane), 0, 0);

        Vector3 targetPosition = new Vector3(VerticalTargetPosition.x, VerticalTargetPosition.y, transform.position.z);
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * sideSpeed;
        controller.Move(moveVector * Time.fixedDeltaTime);

        forwardMove = Vector3.zero;
        forwardMove.z = forwardSpeed;
        controller.Move(forwardMove * Time.fixedDeltaTime);

        if (this.gameObject.transform.position.y < 0f) {
            GameController.Instance.GameEnded(true);
        }
        GameController.Instance.speed.text = "Speed : " + forwardSpeed.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;  
        switch (tag) { 
            case "Crash":
                GameController.Instance.GameEnded(true);
            break;
        
            default:
                break;
        }
    }
}