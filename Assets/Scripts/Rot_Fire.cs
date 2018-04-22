using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rot_Fire : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public AudioSource asource;     
    public AudioClip shotSound;      

    public float bulletSpeed;
    private float Timer;
    public float timeAdjust;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        //asource.volume = PlayerPrefs.GetFloat("Volume");
    }


	void FixedUpdate ()
    {
        Timer -= Time.deltaTime;
        if (!(CrossPlatformInputManager.GetAxis("rot_Vert") == 0 && CrossPlatformInputManager.GetAxis("rot_Hoz") == 0))
        {
            if (Timer < 0.0f)
            {
                Timer = timeAdjust;
                fire();
            }

            rb.MoveRotation(Mathf.Atan2(CrossPlatformInputManager.GetAxis("rot_Hoz"), CrossPlatformInputManager.GetAxis("rot_Vert")) * Mathf.Rad2Deg);
        }
    }

    void fire()
    {
        //print(bulletCount.Length);
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, new Quaternion (0, 0, Mathf.Atan2(CrossPlatformInputManager.GetAxis("rot_Hoz"), CrossPlatformInputManager.GetAxis("rot_Vert")) * Mathf.Rad2Deg * -1, 0));

        bullet.GetComponent<Rigidbody2D>().MoveRotation(Mathf.Atan2(CrossPlatformInputManager.GetAxis("rot_Hoz"), CrossPlatformInputManager.GetAxis("rot_Vert")) * Mathf.Rad2Deg);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.transform.up * bulletSpeed;
        asource.PlayOneShot(shotSound);

        Destroy(bullet, 2.0f);
    }
}

