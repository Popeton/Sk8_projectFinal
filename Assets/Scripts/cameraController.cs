using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset; //sera el desplazamiento de la camra respecto al jugador 

    private void Start()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate() // para que primero se actualice la posicion del jugador y luego la camara lo siga
    {
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newpos, 10 * Time.deltaTime);
    }
}
