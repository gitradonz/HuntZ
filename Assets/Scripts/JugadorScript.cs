using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    [SerializeField] private float velocidad = 7;
    [SerializeField] public float cadenciaDisparo = 1f;
    [SerializeField] public float nDisparos = 1f;
    private float sigDisparo = 0.0F;
    [SerializeField] Transform prefabDisparo;
    [SerializeField] Transform prefabExplosion;	

    Transform disparo;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    void Start()
    {
    }

    void Update()
    {
        // GameObject.Find // Busca un objeto en el escenario
        // Mostrar fps
        // Debug.Log(Time.deltaTime + "seg, " + (1.0f / Time.deltaTime) + "FPS");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (disparoScript.killCount > 9) {
            cadenciaDisparo = 0.7f;
            nDisparos = 2f;
            }
        if (disparoScript.killCount > 29) {
            cadenciaDisparo = 0.5f;
            nDisparos = 3f;
            }
        if (disparoScript.killCount > 49) {
            cadenciaDisparo = 0.2f;
            nDisparos = 5f;
            }
   
        transform.Translate(
        horizontal * velocidad * Time.deltaTime, 
        vertical * velocidad * Time.deltaTime,
        0);
            
        // If the player gets close to the edge of the screen
        if (transform.position.y > 3.8 || transform.position.y < -3.8 ||
        transform.position.x > 7.5 || transform.position.x < -7.5)
        {   
            Debug.Log("He muerto");
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            explosion.GetComponent<AudioSource>().Play();
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
        
        // Shotting
        if (Input.GetButtonDown("Fire1")  && Time.time > sigDisparo)
        {
            sigDisparo = Time.time + cadenciaDisparo;
            spawnDisparo(nDisparos);
        }


    }

    private void spawnDisparo (float nDisparos){
        for (int i = 0; i < nDisparos; i++){ 
            disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();

            // Velocidad y direccion del disparo dependiendo de la posicion del mouse
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x+i, direction.y).normalized * 5; // 5 = velocidad de disparo
        }
    }
    void OnDestroy()
    {
       GameObject.Find("GameController").GetComponent<GameController>().deadText.text = "You died"; 
       GameObject.Find("GameController").GetComponent<GameController>().restartButton.gameObject.SetActive(true);
       GameObject.Find("GameController").GetComponent<GameController>().uploadScore.gameObject.SetActive(true);
       GameObject.Find("GameController").GetComponent<GameController>().backMenu.gameObject.SetActive(true);
       GameObject.Find("GameController").GetComponent<GameController>().nickInput.gameObject.SetActive(true);
    }

}
