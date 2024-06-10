using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerhealthtaker : MonoBehaviour
{
    public AudioManager1 damageaudio; //sound module
    public SpawnMaster spawnmaster;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
        if (spawnmaster.current_base_health - collision.GetComponent<enemybehaviour>().health >= 0)
            spawnmaster.current_base_health -= collision.GetComponent<enemybehaviour>().health;
        else
            spawnmaster.current_base_health = 0;
            damageaudio.Stop();
            damageaudio.Play();
        }
    }
}
