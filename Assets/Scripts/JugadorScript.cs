using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    [SerializeField] private float velocidad = 7;
    [SerializeField] private float velocidadDisparo = 5;
    [SerializeField] Transform prefabDisparo;
    [SerializeField] Transform prefabExplosion;	
    Transform disparo;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public UnityEngine.UI.Text txtPuntos;

    void Start()
    {
       
    }

    void Update()
    {
        // Mostrar fps
        // Debug.Log(Time.deltaTime + "seg, " + (1.0f / Time.deltaTime) + "FPS");
        // Obtener movimiento
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

            
            // GameObject.Find // Busca un objeto en el escenario
   
            transform.Translate(
            horizontal * velocidad * Time.deltaTime, 
            vertical * velocidad * Time.deltaTime,
            0);
            
           if (transform.position.y > 3.8 || transform.position.y < -3.8 ||
            transform.position.x > 8.8 || transform.position.x < -8.8)
        {   
            Debug.Log("He muerto");
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            explosion.GetComponent<AudioSource>().Play();

            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
        
        
            if (Input.GetButtonDown("Fire1"))
            {
                // Instanciamos el disparo
                disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
                GetComponent<AudioSource>().Play();

                // Velocidad y direccion del disparo dependiendo de la posicion del mouse
                mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = mousePos - transform.position;
                disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * velocidadDisparo;
            }

    }

}
