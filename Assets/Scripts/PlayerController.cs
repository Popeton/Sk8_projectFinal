using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Text scoreText;
    public float health = 100;
    [SerializeField] Text CountBar, countBarPower;
    [SerializeField] AudioSource dead;
    [SerializeField] float countMonedas, countPoweUps;
    [SerializeField] Slider Healthbar;
    float multiplicador = 1, count, t;
    public bool canTakeDmg = true;
    bool Activo = true;
    PlayerMovement Move;
    AudioSource audio;
    Collider collider;
    Renderer renderer;
    [SerializeField] Animator animcaida;
    public float invulnerableActiveTime;
    [SerializeField] float invulnerableDuration;
    void Start()
    {
        Move = GetComponent<PlayerMovement>();
        animcaida = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        
         // xd
        Move.Movimiento();
        Move.Salto();
        if (canTakeDmg == false) //si recibir daño es igual a falso  
        {
            if (invulnerableActiveTime <= invulnerableDuration)//activa el powerup, si el tiempo que lleva activo es menor a la duracion que se le pone en el inspector entonces empiece/siga contando los segundos que esta activo
            {
                invulnerableActiveTime += Time.deltaTime;
            }
            else//desactiva el powerup despues de que pase x tiempo
            {
                invulnerableActiveTime = 0;
                canTakeDmg = true;
            }
        }
        countBarPower.text = countPoweUps.ToString();
        //Velocidad();
        switch (PlayerPrefs.GetInt("CharacterSelected")) //escoge el powerup dependiendo del personaje, si no va en este script, feel free to move it uwu
        {
        
            case 0: // piojo
                if (t <= 10)
                {
                    Invulneravilidad();
                    t += Time.deltaTime;
                    print(t);
                }
                
                else
                {
                    canTakeDmg = true;
                }

                
                break;
            case 1:// mono
                

     
               break;
            case 2: // rasta
                VidaRasta();

                break;
        }

    }



    public void Daño(float daño)
    {
        if (canTakeDmg) //si daño es verdadero puede recibir daño 
        {
            health -= daño;
            Healthbar.value = health;
            if (health <= 0)
            {
                animcaida.SetBool("golpeado", Activo);
                Invoke("GameOver", 0.0f);//pantalla final
                audio.Stop();
                Move.speedAdelante = 0;
                Move.speedHor = 0;
                Move.fuerzaSalto = 0;
                dead.Play();
                PlayerPrefs.SetFloat("Distance", player.position.z);//scores en la pantalla final
                PlayerPrefs.SetFloat("PowerWheels", countPoweUps);
            }
        }
        else
        {
            Debug.Log("No recibo daño, estoy melo");
        }
    }
    void GameOver()//metodo para llamar la pantalla de gameover
    {
        print("Deth");
        SceneManager.LoadScene("GameOver");
    }

    

    public void PowerUpMono()// PowerUp del Mono
    {
        Invoke("MultiplicadorTemp", 10);
        count = countPoweUps++;
        multiplicador = 2;
        print(multiplicador);
    }
    public void Almacenar()
    {
        countMonedas += multiplicador;
        CountBar.text = countMonedas.ToString();
        print("funciona");
        PlayerPrefs.SetFloat("Coins", countMonedas);
    }
    void MultiplicadorTemp()
    {
        multiplicador = 1;
    }
    public void PowerUpRasta()
    {
        countPoweUps++;
        if (canTakeDmg)
        {
            canTakeDmg = false;
            invulnerableActiveTime = 0;
        }
    }
    public void PowerUpPiojo()
    {
        countPoweUps++;
        if (health <= 100)
        {
            health += 25f;
            Healthbar.value = health;
        }
    }

  void VidaRasta()
  {
        if (health <= 100)
        {
            health += health/10;
            print(health);
        }
        else if (health > 100)
        {
            health = 100;
            print(health);
        }
        Healthbar.value = health;
  }

    void Invulneravilidad()
    {
        if (canTakeDmg)
        {
            canTakeDmg = false;
            invulnerableActiveTime = 0;
        }
    }

    
    
}
