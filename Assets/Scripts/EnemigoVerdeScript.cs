using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVerdeScript : MonoBehaviour
{
    [SerializeField] private float velocidadX = 2;
    [SerializeField] private float velocidadY = -2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, velocidadY * Time.deltaTime, 0);

        if ((transform.position.x < -8.8) || (transform.position.x > 8.8)) velocidadX = -velocidadX;
        if ((transform.position.y < -3.8) || (transform.position.y > 3.8)) velocidadY = -velocidadY;
    }
}
