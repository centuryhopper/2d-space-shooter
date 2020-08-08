using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 150;

    public AudioClip explosionSound;

    public float explosionVolume = 2f;

    public GameObject explosionEffect;

    public int scorePoints = 50;

    void BlowUp() => Destroy(gameObject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLazer"))
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
        }
    }        

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.DamageOnEnemy;
        damageDealer.DestroyLazer();
        if (health <= 0)
        {
            Debug.Log("BOOM!");
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, explosionVolume);
            Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), 1f);
            FindObjectOfType<GameSession>().AddToScore(scorePoints);
            BlowUp();
        }
    }
}
