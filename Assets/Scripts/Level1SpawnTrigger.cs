using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SpawnTrigger : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enemy1.SetActive(true);
            Enemy2.SetActive(true);
            Enemy3.SetActive(true);
        }
    }
}
