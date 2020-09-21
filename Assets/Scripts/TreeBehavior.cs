using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    public float horizontalSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(horizontalSpeed * Time.deltaTime, 0, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        horizontalSpeed *= -1;
    }
}
