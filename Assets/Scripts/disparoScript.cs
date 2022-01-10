using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoScript : MonoBehaviour
{

    [SerializeField] Transform prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5 || transform.position.y < -5 ||
            transform.position.x > 8.8 || transform.position.x < -8.8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cuando haya colision con un enemigo
        if (other.tag == "Enemigo")
        {
            Debug.Log("Enemigo golpeado");
            // Instanciamos el GameObject de la explosion mediante prefab
            Transform explosion = Instantiate(prefabExplosion, other.transform.position, Quaternion.identity);

            // Sonido de explosion
            explosion.GetComponent<AudioSource>().Play();

            // Destruimos la explosion, el disparo y el enemigo
            Destroy(explosion.gameObject, 1f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }

}
