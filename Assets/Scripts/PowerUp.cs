using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] AudioSource sonido;
    [SerializeField] MeshRenderer renderer;
    ParticleSystem ps;
    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.CompareTag("Player"))
        {
            sonido.Play();
            ps = gameObject.GetComponent<ParticleSystem>();
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            target.GetComponent<PlayerController>().PowerUpMono();
            renderer.enabled = false;
            Invoke("destroy", 2f); //invoke sirve para invocar metodos
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }
}
