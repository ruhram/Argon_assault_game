using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }
    void StartDeathSequence()
    {
        print("Player Dying");
        SendMessage("OnPlayerDeath");
    }
    void OnCollisionEnter(Collision col)
    {
        print("Player Collided Something");
    }
}
