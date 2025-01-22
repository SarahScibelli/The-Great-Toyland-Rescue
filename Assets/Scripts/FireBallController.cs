using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody theRB;

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.forward * moveSpeed;

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.TryGetComponent<PlayerController>(out PlayerController PlayerComponent);
            PlayerComponent.takeDamage(1);
        }

        Destroy(gameObject);
    }
}
