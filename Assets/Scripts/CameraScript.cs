using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform prefabEnemigo;	

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRespawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartRespawnEnemy(){
        yield return new WaitForSeconds(2);
        float positionXrandom = Random.Range(-8.8f, 8.8f);
        float positionYrandom = Random.Range(-3.8f, 3.8f);
        Instantiate(prefabEnemigo, new Vector3(positionXrandom, positionYrandom, 0), Quaternion.identity);
        StartCoroutine(StartRespawnEnemy());
    }
}
