using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PowerUpPiojo : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] AudioSource sonido;
    [SerializeField] MeshRenderer renderer;   
    ParticleSystem ps;
    
    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>(); //se obtiene el mesh render de la rueda
        
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject; //si colisiona con otro objeto que tiene el tag player se cumple la condicion      
        if (target.CompareTag("Player"))
        {           
            sonido.Play();
            ps = gameObject.GetComponent<ParticleSystem>();
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            target.GetComponent<PlayerController>().PowerUpPiojo(); //se obtiene el metodo del piojo que me aumenta la vida            
            renderer.enabled = false; //se apaga el reder
            Invoke("PickUp", 2f); //se destruye dos segundos despues de haber colisionado
            
        }      
    }

    
    void PickUp()
    {      
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }
}
