using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] GameObject[] pickUps;
   
    float t;
    //public Transform[] transforms;
    AudioSource audio;
    void Start()
    {
       
        audio = GetComponent<AudioSource>();
        switch (PlayerPrefs.GetInt("CharacterSelected")) //escoge el powerup dependiendo del personaje, si no va en este script, feel free to move it uwu
        {
            //transforms[Random.Range(0,transforms.Length)]
            //Se deben cambiar de acuerdo al orden en que estén los personajes en el playerprefs, este es el boceto de la vuelta entera
            case 0:
                for (int i = 1; i < pickUps.Length; i++)
                {    
                    Instantiate(pickUps[0], transform.position, transform.rotation);
                }
                
                    Debug.Log("case 0");
                break;
            case 1:
                for (int i = 1; i < pickUps.Length; i++)
                {
                    Instantiate(pickUps[1], transform.position, transform.rotation);
                }

                Debug.Log("case 1");
                break;
            case 2:
                for (int i = 1; i < pickUps.Length; i++)
                {
                    Instantiate(pickUps[2], transform.position, transform.rotation);
                }


                Debug.Log("case 2");
                break;
        }
    }

    void Update()
    {
        
    }
}
