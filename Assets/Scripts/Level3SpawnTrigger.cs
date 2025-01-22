using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level3SpawnTrigger : MonoBehaviour
{
    public GameObject Enemies;
    public GameObject door;
    public TMP_Text health;
    public TMP_Text healthText;
    public Image background1;
    public Image background2;

    public AudioSource source;
    public AudioClip Clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enemies.SetActive(true);
            door.SetActive(true);
            health.gameObject.SetActive(true);
            background1.gameObject.SetActive(true);
            background2.gameObject.SetActive(true);
            healthText.gameObject.SetActive(true);

            source.Stop();
            source.clip = Clip;
            source.Play();
        }
    }
}
