using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private Rigidbody rb;
    private float nextFire;
    private AudioSource weaponAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        weaponAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetButton(ButtonNames.Fire1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            weaponAudio.Play();
        }
    }

    // Executed once per physics step
    private void FixedUpdate()
    {
        Vector3 movement = Movement(speed);
        rb.velocity = movement;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }

    private Vector3 Movement(float speed = 1)
    {
        float moveHorizontal = Input.GetAxis(AxisNames.Horizontal);
        float moveVertical = Input.GetAxis(AxisNames.Vertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        return movement * speed;
    }
}

static class AxisNames
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";
}

static class ButtonNames
{
    public static string Fire1 = "Fire1";
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}