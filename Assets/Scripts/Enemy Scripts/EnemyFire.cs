using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float minTimeBtwShots = 0.2f;
    public float maxTimeBtwShots = 10f;
    float shotCounter;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    public AudioClip lazerSound;

    public float fireVolume = .5f;


    // Start is called before the first frame update
    void Start()
    {
        float shotCounter = UnityEngine.Random.Range(minTimeBtwShots, maxTimeBtwShots);
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBtwShots, maxTimeBtwShots);
        }
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(lazerSound, transform.position, fireVolume);
        GameObject enemyBullet = Instantiate(bulletPrefab,
                                    firePoint.position,
                                    Quaternion.identity);
        enemyBullet.GetComponent<Rigidbody2D>().velocity =
            new Vector2(0, bulletSpeed > 0f ? -bulletSpeed : bulletSpeed);

        Destroy(enemyBullet, 3f);
    }
}
