using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    private bool haveKey = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            haveKey = true;
            Debug.Log("Key Collected");

        }

        if (other.gameObject.tag == "Gate" && haveKey == true)
        {
            other.gameObject.SetActive(false);
            haveKey = false;

        }

    }
}
