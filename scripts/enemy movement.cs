using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemymovement: MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    int indx = 0;
    Vector3 position1;
    Vector3 position2;
    Rigidbody rb;
    public float speed;
    float y;

    void Start()
    {
        // target1=GameObject.Find("Triger1").GetComponent<GameObject>();
        // target2=GameObject.Find("Triger2").GetComponent<GameObject>();
        y = this.gameObject.transform.position.y;
        position1 = new Vector3(target1.transform.position.x, y, target1.transform.position.z);
        position2 = new Vector3(target2.transform.position.x, y, target2.transform.position.z);
        transform.LookAt(position1);

    }

    void Update()
    {
        if (indx == 0)
            transform.LookAt(position1);
        else
            transform.LookAt(position2);
        //rb.MovePosition(new Vector3(transform.position.x, 0, transform.position.z) + Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z) + transform.forward * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided with:"+ gameObject.tag.ToString() + gameObject.layer.ToString());
        if (collision.GetComponent<Collider>().gameObject.tag == "turn")
        {
            indx = 1;
        }
        if (collision.GetComponent<Collider>().gameObject.tag == "die")
        {
            Destroy(this.gameObject);
        }

    }
}
