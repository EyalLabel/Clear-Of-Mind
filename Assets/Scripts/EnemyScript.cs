using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 1;
    private bool isDying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage, Quaternion rotation)
    {
        health = health - damage;
        Debug.Log("health is" + health);
        
        if (health < 1)
        {
            if (!isDying) Die();
            //onEnemyDeath.Invoke();
        }
    }
    void Die()
    {
        isDying = true;
        //enemyDeath.Invoke();
        //GameObject DeathEffect = Instantiate(DeathEffectPrefab, spawnPoint.position, DeathEffectPrefab.transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("Bullet")) 
        {
            TakeDamage(1, collision.transform.rotation);
        }
    }
}
