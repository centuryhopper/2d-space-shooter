using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletSpeed = 20f;

    public float projectileFiringPeriod = 0.5f;

    Coroutine coroutine;

    public AudioClip lazerSound;

    public float fireVolume = .5f;

    // Start is called before the first frame update
    void Start()
    {
        // fires continuously
        //Fiya();
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(lazerSound, transform.position, fireVolume);

            // could pass in transform.rotation if the player can rotate but in this game, it can't.
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);

            Destroy(bullet, 3f);
            yield return new WaitForSeconds(projectileFiringPeriod);
            //Destroy(bullet);
        }
    }

    void Fiya()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            coroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(coroutine);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fiya();
    }
}
