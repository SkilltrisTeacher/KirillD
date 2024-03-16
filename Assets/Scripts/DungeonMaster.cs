using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Help health = collision.GetComponent<Help>();
        if (health!= null)
        {
            health.TakeDamage();
        }

    }
}
