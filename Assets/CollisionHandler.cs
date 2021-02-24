using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Second")][SerializeField] float LevelLoadDelay = 1f;
    [Tooltip("FX Prefab On Player")][SerializeField] GameObject deathFx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFx.SetActive(true);
        Invoke("ReloadScene", LevelLoadDelay);
    }
    void StartDeathSequence()
    {
        print("Player Dying");
        SendMessage("OnPlayerDeath");
    }
    private void ReloadScene() //string reference
    {
        SceneManager.LoadScene(1);
    }
    void OnCollisionEnter(Collision col)
    {
        print("Player Collided Something");
    }
}
