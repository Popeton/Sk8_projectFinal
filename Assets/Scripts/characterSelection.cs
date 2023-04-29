using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSelection : MonoBehaviour
{
    [SerializeField] AudioSource sonido;
    GameObject[] characterList;
    int index;
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];
        //Llenamos el arreglo con nuestros personajes
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        // apagamos los renders de nuestros personajes
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //encendemos el primero gameobject del index
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }        
    }

    public void ToggleLeft()
    {
        sonido.Play();
        //se apaga el personaje actual
        characterList[index].SetActive(false); 
        // se mueve entre el arreglo(osea los personajes)
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        //enciende el nuevo modelo 
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        sonido.Play();
        //se apaga el personaje actual
        characterList[index].SetActive(false);
        // se mueve entre el arreglo(osea los personajes)
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        //enciende el nuevo modelo 
        characterList[index].SetActive(true);
    }
    public void ConfirmButton()
    {
        sonido.Play();
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
