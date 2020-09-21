using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    private float minX = -7f;
    private float maxX = 7f;

    void Update()
    {
        if (!GameManager.instance.GameEnd()) {
            float mouseXPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if (mouseXPosition >= minX && mouseXPosition <= maxX) transform.position = new Vector3(mouseXPosition,transform.position.y,transform.position.z);
            else if (mouseXPosition < minX) transform.position = new Vector3(minX,transform.position.y,transform.position.z);
            else if (mouseXPosition > maxX) transform.position = new Vector3(maxX,transform.position.y,transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ("Apple".Equals(collision.gameObject.tag)) {
            GameManager.instance.AddPoint();
        }
    }
}
