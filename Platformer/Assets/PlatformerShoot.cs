using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerShoot : MonoBehaviour
{

    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 2.0f;
    public AudioClip shootSound;
    private float timer = 0;
    public float shootDelay = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            //when the mouse is clicked
            if (Input.GetButtonDown("Fire1") && timer > shootDelay)
            {
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = -Camera.main.transform.position.z;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 shootDir = mousePosition - transform.position;
                shootDir.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
                //Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
                Destroy(bullet, bulletLifetime);
                timer = 0;
            }
        }
    }
}
