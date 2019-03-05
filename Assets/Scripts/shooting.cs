using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject projectile;
    private Transform playerPos;

    //sfx
    private AudioSource aSource;
    public AudioClip checkpointSound;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GetComponent<Transform>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, playerPos.position, Quaternion.identity);
        }

    }
}
