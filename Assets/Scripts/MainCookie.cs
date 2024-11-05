using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCookie : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObjects[0].gameObject.transform.Rotate(0, 0, rotationSpeed);
    }
}
