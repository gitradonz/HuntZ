using UnityEngine;

public class gameController : MonoBehaviour
{

    public UnityEngine.UI.Text kills;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        kills.text = disparoScript.killCount.ToString();
    }
}
