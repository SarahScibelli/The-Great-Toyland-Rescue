using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour

{
    public Transform firePoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireShot", 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireShot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
