using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform prefabEnemigo;	

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabEnemigo, new Vector3(1, 0, 0), Quaternion.identity);
        Instantiate(prefabEnemigo, new Vector3(2, 2, 0), Quaternion.identity);
        Instantiate(prefabEnemigo, new Vector3(3, 3, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
