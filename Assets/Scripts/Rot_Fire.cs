using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rot_Fire : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    private float Timer;
    public float timeAdjust;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }


	void FixedUpdate ()
    {
        Timer -= Time.deltaTime;
        if (CrossPlatformInputManager.GetAxis("rot_Vert") == 0 && CrossPlatformInputManager.GetAxis("rot_Hoz") == 0)
        {
            //rb.MoveRotation(0.0f);
        }
        else
        {
            
            if (Timer < 0.0f)
            {
                Timer = timeAdjust;
                fire();
            }
            
            rb.MoveRotation(Mathf.Atan2(CrossPlatformInputManager.GetAxis("rot_Hoz"), CrossPlatformInputManager.GetAxis("rot_Vert")) * Mathf.Rad2Deg * -1);

        }
        
    }

    void fire()
    {
        //print(bulletCount.Length);
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, new Quaternion (0, 0, Mathf.Atan2(CrossPlatformInputManager.GetAxis("rot_Hoz"), CrossPlatformInputManager.GetAxis("rot_Vert")) * Mathf.Rad2Deg * -1, 0));

        bullet.GetComponent<Rigidbody2D>().MoveRotation(Mathf.Atan2(CrossPlatformInputManager.GetAxis("rot_Hoz"), CrossPlatformInputManager.GetAxis("rot_Vert")) * Mathf.Rad2Deg * -1);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.transform.up * bulletSpeed;

        Destroy(bullet, 2.0f);
    }
}

