using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particula : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem particulas;
    void Start()
    {
        particulas = GetComponentInChildren<ParticleSystem>();
    }

    public void ps()
    {
        //particulas.Stop();
    }
}
