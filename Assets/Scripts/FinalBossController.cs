using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalBossController : MonoBehaviour
{
    //Fireball
    public Transform firePoint;
    public GameObject bullet;

    // Movement
    public Transform player;
    public float speed;
    private float distance;
    public float distanceBetween;
    Rigidbody rb;

    // Health
    [SerializeField] float health, maxHealth = 10f;

    public TMP_Text healthText;

    // Animation
    Animator animator;

    // End Game
    public TMP_Text winText;
    public Image winImage;
    public TMP_Text bossText;
    public TMP_Text bossHealth;
    public Image bossImage;
    public Image bossImage2;
    public GameObject Princess_idle;
    public GameObject Princess_win;
    public AudioSource source;
    public AudioClip Clip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;

        animator = GetComponent<Animator>();

        InvokeRepeating("FireShot", 5, 3);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();

        //distance = Vector3.Distance(transform.position, player.transform.position);

        //if (distance < distanceBetween)
        //{
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
            transform.LookAt(player);
            animator.SetBool("isMoving", true);
        /*}
        else
        {
            animator.SetBool("isMoving", false);
        }*/
    }

    void FireShot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
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

        if (health <= 0)
        {
            winText.gameObject.SetActive(true);
            winImage.gameObject.SetActive(true);
            bossText.gameObject.SetActive(false);
            bossHealth.gameObject.SetActive(false);
            bossImage.gameObject.SetActive(false);
            bossImage2.gameObject.SetActive(false);
            Princess_idle.gameObject.SetActive(false);
            Princess_win.gameObject.SetActive(true);
            source.Stop();
            source.clip = Clip;
            source.Play();
            Cursor.lockState = CursorLockMode.None;
            Destroy(gameObject);
        }
    }
}
