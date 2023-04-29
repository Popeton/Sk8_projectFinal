using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dificultad : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Text scoreText;
    float t = 0;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        Time.timeScale = 0.9f + t * 0.007f;
        scoreText.text = player.position.z.ToString("0");
    }
}
