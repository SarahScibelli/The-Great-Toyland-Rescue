using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public static PlayerController instance;

    public float moveSpeed, gravityModifier, jumpPower, runSpeed = 12f;
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;

    public float mouseSensitivity;
    public bool invertX;
    public bool invertY;

    public LayerMask whatIsGround;

    public Transform firePoint;

    public GameObject bullet;

    // Health
    [SerializeField] float playerhealth, playerMaxHealth = 6f;

    public TMP_Text health;

    // Gate variables
    private bool haveKey = false;
    public GameObject Gate1L;
    public GameObject Gate1R;
    public GameObject Gate2L;
    public GameObject Gate2R;

    void Start()
    {
        playerhealth = playerMaxHealth;
    }

    void Update()
    {
            float yStore = moveInput.y;

            Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
            Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

            moveInput = horiMove + vertMove;
            moveInput.Normalize();

            health.text = playerhealth.ToString();

            if (Input.GetKey(KeyCode.LeftShift))
            {
            //StartCoroutine(dodge());
            moveInput = moveInput * runSpeed;
        }
            else
            {
                moveInput = moveInput * moveSpeed;
            }

            moveInput.y = yStore;

            moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

            if (charCon.isGrounded)
            {
                moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
            }
            //Handle Jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveInput.y = jumpPower;

            } 

            charCon.Move(moveInput * Time.deltaTime);

            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            if (invertX)
            {
                mouseInput.x = -mouseInput.x;
            }
            if (invertY)
            {
                mouseInput.y = -mouseInput.y;
            }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

            camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        if (Input.GetMouseButtonDown(0))
            {
                FireShot();
            } 
        
    }

            void FireShot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public void takeDamage(float damageNum)
    {
        playerhealth -= damageNum;

        //StartCoroutine(regainHealth());

        if (playerhealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            other.gameObject.SetActive(false);
            haveKey = true;

        }

        if (other.gameObject.tag == "Lock1" && haveKey == true)
        {
            other.gameObject.SetActive(false);
            Gate1L.SetActive(false);
            Gate1R.SetActive(false);
            haveKey = false;
            playerhealth = playerMaxHealth;

        }

        if (other.gameObject.tag == "Lock2" && haveKey == true)
        {
            other.gameObject.SetActive(false);
            Gate2L.SetActive(false);
            Gate2R.SetActive(false);
            haveKey = false;
            playerhealth = playerMaxHealth;

        }

    }

    /*IEnumerator dodge()
    {
        yield return new WaitForSeconds(1);
        moveInput = moveInput * runSpeed;
    }*/
    /*IEnumerator regainHealth()
    {
        yield return new WaitForSeconds(5);
        playerhealth += 1;
    }*/



}
