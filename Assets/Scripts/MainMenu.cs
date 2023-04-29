using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource sonidoboton;
 
    public void PlayGame()
    {
        sonidoboton.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        sonidoboton.Play();
        print("quit");
        Application.Quit();
    }
}
