using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    [SerializeField] private float velocidad = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mostrar fps
        //Debug.Log(Time.deltaTime + "seg, " + (1.0f / Time.deltaTime) + "FPS");

        // Obtener movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(
            horizontal * velocidad * Time.deltaTime, 
            vertical * velocidad * Time.deltaTime,
            0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Golpeado");
    }
}
