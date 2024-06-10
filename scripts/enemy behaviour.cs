using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemybehaviour : MonoBehaviour
{
    public int health;
    int current_health;
    public Canvas canvas;
    public Slider slider;
    void Start()
    {
        current_health = health;
        slider.maxValue = health;
        canvas.enabled = false;
    }

    public void take_damage( int damage)
    {
        canvas.enabled = true;
        current_health -= damage;
        if (current_health <= 0)
        {
            current_health -= damage;
            Debug.Log("Took" + damage + "damage and died");
            Destroy(this.gameObject);
        }
        else
        {
            slider.value = current_health;
        }
    }
}
