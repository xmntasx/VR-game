using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcollides : MonoBehaviour
{
    public int damage = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 0 || collision.collider.gameObject.layer == 8)
        {
            if (collision.collider.gameObject.layer == 8) 
            { 
                collision.gameObject.GetComponent<enemybehaviour>().take_damage(damage);
                Debug.Log("hit");
            }

            Destroy(this.gameObject);
        }
        timer(5);
    }
    IEnumerator timer(int time)
    {
        yield return new WaitForSeconds(time);
        if (this!=null)
        Destroy(this.gameObject);
    }
}
