using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    private Vector2 target;
    public float projectileSpeed;

    //sfx
    private AudioSource aSource;
    public AudioClip checkpointSound;

    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position,target) <0.2f)
        {
            Destroy(gameObject);
        }
    }
}
