using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class basegun : MonoBehaviour
{
    //will be used for haptics
    //public InputActionProperty rightgrip; // right controller data
    //public InputActionProperty righttrigger; // right controller data
    //public InputActionProperty leftgrip; // left controller data
    //public InputActionProperty lefttrigger; // left controller data

    [Range(0, 1)]
    public float intensity;
    public float duration;

    public AudioManager1 shotaudio; //sound module
    public AudioManager1 dryfire; //sound module
    public TextMeshProUGUI ammo_counter; // ammo counter - display
    public int ammo_count; // ammo count for the gun
    int current_ammo_count;

    public GameObject bullet;
    public Transform spawn_point;
    public float fire_speed = 20;
    void Start()
    {
        current_ammo_count = ammo_count;
        ammo_counter.text=ammo_count.ToString();
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerHaptic);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot()
    {
        if (current_ammo_count > 0)
        {
            current_ammo_count -= 1;
            ammo_counter.text = current_ammo_count.ToString();
            if (current_ammo_count <= 5)
            {
                shotaudio.Stop();
                dryfire.Stop();
                dryfire.pitch += 0.1f;
                shotaudio.pitch += 0.1f ;
                shotaudio.Play();
                dryfire.Play();

                ammo_counter.color = new Color(255, 0, 0);
            }
            else
            {
                shotaudio.Stop();
                shotaudio.Play();
                ammo_counter.color = new Color(255, 236, 0);
            }
            GameObject spawned_bullet = Instantiate(bullet);
            spawned_bullet.transform.position = spawn_point.position;
            spawned_bullet.GetComponent<Rigidbody>().velocity = spawn_point.forward * fire_speed;
        }
        else 
        {
            shotaudio.pitch = 1;
            dryfire.pitch = 1;
            dryfire.Stop();
            dryfire.Play();
        }

    }

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (current_ammo_count > 0)
        {
            shotaudio.Stop();
            shotaudio.Play();
            controller.SendHapticImpulse(intensity, duration);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("gun"+ collision.collider.gameObject.tag);
        if (collision.collider.gameObject.layer == 0)
        {

            if (collision.collider.gameObject.tag=="die")
            {
                Destroy(this.gameObject);
            }
            if (collision.collider.gameObject.tag =="other")
            { 
                Destroy(this.gameObject);
            }
        }
    }


}
