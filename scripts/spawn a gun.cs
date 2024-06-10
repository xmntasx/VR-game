using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    public GameObject gun;
    GameObject spawned;
    public Transform place;
    // Start is called before the first frame update
    void Start()
    {
      spawned = Instantiate(gun,place);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == null)
        {
            spawned = Instantiate(gun, place);
        }
    }
}
