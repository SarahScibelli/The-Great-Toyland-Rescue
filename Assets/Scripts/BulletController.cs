using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody theRB;

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.forward * moveSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" ){
            other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent);
            enemyComponent.takeDamage(1);     
        }

        if (other.gameObject.tag == "FinalBoss")
        {
            other.gameObject.TryGetComponent<FinalBossController>(out FinalBossController BossComponent);
            BossComponent.takeDamage(1);
        }

        Destroy(gameObject);
    }
}