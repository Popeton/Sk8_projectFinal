using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button playButton, quitButton;
    [SerializeField] AudioSource sonidoboton;
    [SerializeField] Text dist, coin, wheel;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(Menu);
        dist.text = "DISTANCE: " + Mathf.Round(PlayerPrefs.GetFloat("Distance"));
        coin.text = "COINS: " + Mathf.Round(PlayerPrefs.GetFloat("Coins"));
        wheel.text = "POWER WHEELS: " + Mathf.Round(PlayerPrefs.GetFloat("PowerWheels"));
    }

    public void PlayAgain()//carga la escena del menú
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()//mismo método del menú
    {
        sonidoboton.Play();
        SceneManager.LoadScene(0);
    }
}
