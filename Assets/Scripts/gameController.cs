using System.Collections;
using UnityEngine;


public class GameController : MonoBehaviour
{

    [SerializeField] Transform prefabEnemigo;	
    public UnityEngine.UI.Text kills;
    public UnityEngine.UI.Text level;
    public UnityEngine.UI.Text deadText;
    public UnityEngine.UI.Text nickError;
    public UnityEngine.UI.Button restartButton;
    public UnityEngine.UI.Button uploadScore;
    public UnityEngine.UI.Button backMenu;
    public UnityEngine.UI.InputField nickInput;
    public float enemySpawnSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRespawnEnemy());
    }


    // Update is called once per frame
    void Update()
    {
        kills.text = disparoScript.killCount.ToString();
        if (disparoScript.killCount == 10){
            level.text = "Level 2";
            enemySpawnSpeed = 1f;
        }
         if (disparoScript.killCount == 30){
            level.text = "Level 3";
            enemySpawnSpeed = 0.5f;
        }
        if (disparoScript.killCount == 50){
            level.text = "Final Level";
            enemySpawnSpeed = 0.2f;
        }
        
    }

     IEnumerator StartRespawnEnemy(){
        yield return new WaitForSeconds(enemySpawnSpeed);
        float positionXrandom = Random.Range(-7.5f, 7.5f);
        float positionYrandom = Random.Range(-3.8f, 3.8f);
        Instantiate(prefabEnemigo, new Vector3(positionXrandom, positionYrandom, 0), Quaternion.identity);
        StartCoroutine(StartRespawnEnemy());
    }

    
}
