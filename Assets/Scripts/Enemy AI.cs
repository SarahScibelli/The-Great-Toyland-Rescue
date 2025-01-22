using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Movement
    public Transform player;
    public float speed;
    private float distance;
    public float distanceBetween;
    Rigidbody rb;

    // Health
    [SerializeField] float health, maxHealth = 3f;

    // Animation
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        //Vector3 direction = player.transform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.z) * Mathf.Rad2Deg;

        if(distance < distanceBetween)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
            transform.LookAt(player);
            animator.SetBool("isMoving", true);
            //transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerComponent);
            playerComponent.takeDamage(1);
            Debug.Log("Player took a hit");
        }

    }

    public void takeDamage(float damageNum)
    {
        health -= damageNum;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
