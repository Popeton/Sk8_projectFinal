using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speedHor = 20;
    [SerializeField] public float speedAdelante = 20;
    [SerializeField] public float fuerzaSalto = 50,cooldownSalto = 3;
    [SerializeField] string horizontal = "Horizontal", salto = "Jump";
    [SerializeField] bool animacionSalto = false;
    [SerializeField] AudioSource skateSound;
    float t = 0;
    int moveHorizontal = 0; //-1 Izquierda, 0 Mitad, 1 Derecha 
    Vector3 moveVector;
    Rigidbody rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        t = cooldownSalto;
    }
    void Update()
    {
    
    }
    public void Movimiento()
    {      
        Vector3 dirX = transform.right;
        Vector3 velocidadX = speedHor * dirX * Input.GetAxis(horizontal);
        transform.position += velocidadX * Time.deltaTime;

        Vector3 dirZ = transform.forward;
        Vector3 velocidadZ = speedAdelante * dirZ;
        transform.position += velocidadZ * Time.deltaTime;
    }
    public void Salto() //esto es un metodo
    {
        bool saltar = Input.GetButtonDown(salto); //getbuttondown es la barra espaciadora
        if (saltar && t >= cooldownSalto)
        {
            skateSound.Stop();
            print("salta");
            Vector3 forceV3 = transform.up * fuerzaSalto;
            rb.AddForce(forceV3);
            anim.SetBool("salto", saltar);
            t = 0;
        }
        t += Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.CompareTag("Piso"))
        {
            skateSound.Play();
            anim.SetBool("salto", false);
        }
    }
}
