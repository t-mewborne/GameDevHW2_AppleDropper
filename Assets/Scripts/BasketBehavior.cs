using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameManager gm;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ("Apple".Equals(collision.gameObject.tag)) {
            Debug.Log("apple detected");
            GameManager.instance.AddPoint();
        }
    }
}
