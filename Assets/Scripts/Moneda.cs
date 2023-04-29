using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : MonoBehaviour
{
    [SerializeField] float countMoneda, valorMoneda;
    [SerializeField] AudioSource monedaSound;
    [SerializeField] MeshRenderer renderer;
    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.CompareTag("Player"))
        {
            monedaSound.volume = 0.1f;
            monedaSound.Play();
            target.GetComponent<PlayerController>().Almacenar();
            print("almacena");
            renderer.enabled = false;
            Invoke("destroy", 1f);   
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
    
 
}
