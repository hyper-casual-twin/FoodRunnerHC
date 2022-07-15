using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerUp : MonoBehaviour
{
    public enum PowerUpTypes
    {
        apple,
        banana,
        appleBanana
    }
    public PowerUpTypes PowerUp;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (PowerUp == PowerUpTypes.apple)
                    PlayerMovement.Instance.forwardSpeed = 1.5f;
                else if (PowerUp == PowerUpTypes.banana)
                    PlayerMovement.Instance.forwardSpeed = 1.7f;
                else if (PowerUp == PowerUpTypes.appleBanana)
                    PlayerMovement.Instance.forwardSpeed = 2f;
                    break;
            default:
                break;
        }
    }
}
