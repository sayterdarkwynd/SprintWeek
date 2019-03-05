using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
   
    // Core Stats
    public float maxSpeed;//max speed we can reach
    public float rotationSpeed;//rate of turn
    public float resourceBonus;//bonus to gained resources
    public float bonusDamage;//damage bonus. applied before armor reductions.

    //health
    public int health;
    public int maxHealth;
    public Text healthDisplay;

    // body data
    private Rigidbody2D rb;

    // basic weapon controls, params
    public float weaponDamage;//current outgoing damage (before armor)
    public int activeWeapon;//which weapon is active? (list)
    public int numOfProjectiles;//how many are we firing?
    public float projectileDistance;//how spread are the projectiles?

    //particle effects
    public ParticleSystem particles; //thruster particles
   
    //sfx
    private AudioSource aSource;
    public AudioClip checkpointSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        healthDisplay.text = "Health :" + health;//write to UI

        if (health <= 0) //if health hits 0, reset scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //apply movement if inputs are pressed
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
 
        ThrustForward(yAxis);
        Rotate(transform,xAxis * -rotationSpeed);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float y = Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
        ClampVelocity();

        if (force.x != 0 || force.x != 0 ) {
            GameObject effect = Instantiate(particles.gameObject, transform.position, transform.rotation); //spawn thruster particles
            Destroy(effect, 0.5f);
        }

    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

}
