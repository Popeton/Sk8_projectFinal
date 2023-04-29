using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRasta : MonoBehaviour
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
            target.GetComponent<PlayerController>().PowerUpRasta(); //se obtiene el metodo de la Rasta que me vuelve inmune por x segundos
            renderer.enabled = false; //se apaga el render
            Invoke("PickUp", 2f);
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
