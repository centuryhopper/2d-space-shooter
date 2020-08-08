using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageOnEnemy = 50;
    [SerializeField] int damageOnPlayer = 50;

    public int DamageOnEnemy
    {
        get { return damageOnEnemy; }
    }

    public int DamageOnPlayer
    {
        get { return damageOnPlayer; }
    }

    public void DestroyLazer() => Destroy(gameObject);
}
