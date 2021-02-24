using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreperhit = 12;
    [SerializeField] int HealthPoint = 3;
    scoreBoard ScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        addNonTriggerCollider();
    }

    private void addNonTriggerCollider()
    {
        AddBoxCollider();
        ScoreBoard = FindObjectOfType<scoreBoard>();
    }
    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (HealthPoint <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        ScoreBoard.scorehit(scoreperhit);
        HealthPoint--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
