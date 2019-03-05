using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private player player;

    //particle effects
    public ParticleSystem particlesMove;
    public ParticleSystem particlesDeath;

    //sfx
    private AudioSource aSource;
    public AudioClip checkpointSound;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        GameObject effect = Instantiate(particlesMove.gameObject, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health--;
            Debug.Log(player.health);
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
            GameObject effect = Instantiate(particlesDeath.gameObject, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
