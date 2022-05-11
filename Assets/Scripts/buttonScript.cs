using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LanzarJuego()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReiniciarJuego(){
        // Restart the game
        GameObject.Find("GameController").GetComponent<GameController>().kills.text = "0";
        GameObject.Find("GameController").GetComponent<GameController>().level.text = "Level 1";
        GameObject.Find("GameController").GetComponent<GameController>().enemySpawnSpeed = 2f;        
        disparoScript.killCount = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void UploadScore(){
        Debug.Log("Uploading score");
    }
    
}
