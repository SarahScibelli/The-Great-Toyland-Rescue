using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SpawnTrigger : MonoBehaviour
{
    public GameObject Enemies;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enemies.SetActive(true);
        }
    }
}
