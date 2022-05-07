using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVerdeScript : MonoBehaviour
{
    [SerializeField] private float velocidadX = 2;
    [SerializeField] private float velocidadY = -2;
    [SerializeField] private float velocidadDisparo = 2;
    [SerializeField] Transform prefabShuriken;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, velocidadY * Time.deltaTime, 0);

        if ((transform.position.x < -8.8) || (transform.position.x > 8.8)) velocidadX = -velocidadX;
        if ((transform.position.y < -3.8) || (transform.position.y > 3.8)) velocidadY = -velocidadY;
    }

    IEnumerator Disparar()
    {
        float pausa = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabShuriken,transform.position, Quaternion.identity);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
        StartCoroutine( Disparar() );
    }

}
