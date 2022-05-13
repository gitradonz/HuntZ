using System.Collections;
using UnityEngine;

public class EnemigoVerdeScript : MonoBehaviour
{
    [SerializeField] private float velocidadX = 2;
    [SerializeField] private float velocidadY = -2;
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

        if ((transform.position.x < -7.5) || (transform.position.x > 7.5)) velocidadX = -velocidadX;
        if ((transform.position.y < -3.8) || (transform.position.y > 3.8)) velocidadY = -velocidadY;
    }

    IEnumerator Disparar()
    {
        float pausa = Random.Range(1.0f, 2.0f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabShuriken,transform.position, Quaternion.identity);
        
        float velocidadX = Random.Range(-8f, 8f);
        float velocidadY = Random.Range(-3.8f, 3.8f);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(velocidadX, velocidadY, 0).normalized * 5;


        StartCoroutine( Disparar() );
    }

}
