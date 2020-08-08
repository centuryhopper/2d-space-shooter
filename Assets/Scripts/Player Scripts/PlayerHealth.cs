using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 200;

    public AudioClip explosionSound;

    public float explosionVolume = 2f;

    public GameObject explosionEffect;

    void BlowUp()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLazer"))
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.DamageOnPlayer;
        damageDealer.DestroyLazer();
        if (health <= 0)
        {
            Debug.Log("BOOM!");
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, explosionVolume);
            Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), 1f);
            BlowUp();
            GameObject.Find("Level Manager").GetComponent<LevelManager>().LoadGameOver();
        }
    }
}
