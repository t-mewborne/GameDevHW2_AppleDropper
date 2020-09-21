using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ("Basket".Equals(collision.gameObject.tag))
        {
            Destroy(this.gameObject);
        }
        if ("OutOfBounds".Equals(collision.gameObject.tag))
        {
            Destroy(this.gameObject);
            
        }
    }
}
