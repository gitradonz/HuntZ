using UnityEngine;
using Firebase.Database;
using UnityEngine.SceneManagement;



public class buttonScript : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference;
    // Start is called before the first frame update
    void Start()
    {
        userID = Random.Range(0, 100000).ToString();
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
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
        cleanInfo();
        SceneManager.LoadScene("GameScene");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void UploadScore(){
        if (GameObject.Find("GameController").GetComponent<GameController>().nickInput.text.Length > 3 &&
            GameObject.Find("GameController").GetComponent<GameController>().nickInput.text.Length < 10){
                User newUser = new User(
                    GameObject.Find("GameController").GetComponent<GameController>().nickInput.text,
                    disparoScript.killCount);

                string json = JsonUtility.ToJson(newUser);

                dbReference.Child("Jugadores")
                .Child(userID)
                .SetRawJsonValueAsync(json);

                cleanInfo();
                SceneManager.LoadScene("MenuScene");
        }else{
           GameObject.Find("GameController").GetComponent<GameController>().nickError.gameObject.SetActive(true);
        }
    }

    void cleanInfo(){
        GameObject.Find("GameController").GetComponent<GameController>().kills.text = "0";
        GameObject.Find("GameController").GetComponent<GameController>().level.text = "Level 1";
        GameObject.Find("GameController").GetComponent<GameController>().enemySpawnSpeed = 2f;        
        disparoScript.killCount = 0;
    }

    public void exitGame(){
        Application.Quit();
    }

    public void clickTutorial(){
        SceneManager.LoadScene("TutorialScene");
    }

    public void clickCredits(){
        SceneManager.LoadScene("CreditsScene");
    }
    
}
