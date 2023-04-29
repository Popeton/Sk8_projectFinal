using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ColisionDeObjetos : MonoBehaviour
{
    [SerializeField] float daño = 50; //daño del objeto
    PlayerController health;
    Renderer renderer;
    Collider collider;
    AudioSource sonido;
   
    // Start is called before the first frame update
    void Start()
    {     
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.CompareTag("Player"))
        {
            print("colision");
            sonido.Play();
            health = target.GetComponent<PlayerController>();
            health.Daño(daño);
            renderer.enabled = false;
            collider.enabled = false;
            Invoke("destroy", 1f);
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
}

