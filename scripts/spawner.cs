using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public int max_time_in_seconds_between_spawns;
    public SpawnMaster spawn_master;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    float timer;
    float time_to_wait;
    // Start is called before the first frame update
    void Start()
    {
        time_to_wait = UnityEngine.Random.value * max_time_in_seconds_between_spawns;
        if (time_to_wait < 1)
            time_to_wait = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time_to_wait)
        {
            timer = 0;
            time_to_wait = UnityEngine.Random.value * max_time_in_seconds_between_spawns;
            if (time_to_wait < 1)
                time_to_wait = 1;
            int i = Mathf.RoundToInt(UnityEngine.Random.value * 2);

            if (i == 2 && spawn_master.budget >= 60)
            {
                if (spawn_master.budget==60)
                spawn_master.lastspawned=Instantiate(enemy3, this.transform);
                else
                Instantiate(enemy3, this.transform);
                spawn_master.budget -= 60;
            }
            else if (i == 1 && spawn_master.budget >= 40 || spawn_master.budget >= 40 && spawn_master.budget < 60)
            {
                if (spawn_master.budget == 40)
                spawn_master.lastspawned = Instantiate(enemy2, this.transform);
                else
                Instantiate(enemy2, this.transform);
                spawn_master.budget -= 40;
            }
            else if (i == 0 && spawn_master.budget >= 20 || spawn_master.budget >= 20 && spawn_master.budget < 40)
            {
                if (spawn_master.budget == 20)
                spawn_master.lastspawned = Instantiate(enemy1, this.transform);
                else
                Instantiate(enemy1,this.transform);
                spawn_master.budget -= 20;
            }
        }
    }
}
