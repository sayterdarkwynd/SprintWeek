using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoint;
    private float spawnTime;
    public float spawnInterval;
    public ParticleSystem particles;

    void Start() {
        spawnTime = spawnInterval;
    }

    void Update()
    {
        if (spawnTime <= 0)
        {
            int randPos = Random.Range(0, spawnPoint.Length );
            Instantiate(enemy, spawnPoint[randPos].position, Quaternion.identity);
            spawnTime = spawnInterval;
            GameObject effect = Instantiate(particles.gameObject, spawnPoint[randPos].position, transform.rotation);
            Destroy(effect, 0.5f);
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }

    }
}
