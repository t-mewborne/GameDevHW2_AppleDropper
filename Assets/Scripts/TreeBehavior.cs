using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    public float horizontalSpeed;
    public float appleSpawnRate;
    public float appleSpawnDelay;
    public float minAppleSpawnDelay;
    public float appleSpawnAcceleration;
    public GameObject apple;

    void Start()
    {
        InvokeRepeating("Spawn",appleSpawnDelay,appleSpawnRate);
        if (minAppleSpawnDelay > appleSpawnDelay) Debug.Log("appleSpawnDelay should be greater than its minimum, minAppleSpawnDelay.");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(horizontalSpeed * Time.deltaTime, 0, 0);
        if (appleSpawnDelay > minAppleSpawnDelay) {
            appleSpawnDelay -= appleSpawnAcceleration * Time.deltaTime;
        }
    }
    
    void Spawn() {
        Instantiate(apple,transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ("OutOfBounds".Equals(collision.gameObject.tag)) {
            horizontalSpeed *= -1;
        }
    }
}
