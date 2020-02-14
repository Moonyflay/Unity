using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 80.0F;
    Vector3 direction;
    public Vector3 Direction 
    { set { direction = value; } }
    private void Start()
    {
        Destroy(gameObject, 1.0F);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed *Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name != "Player")
        { Destroy(gameObject); }

        //if (collider.GetComponent<Player>() != null) { }
        //else
        //{
        //    Destroy(gameObject);
        //}
                                                                
            if (collider.GetComponent<Barier>() != null && collider.GetComponent<Barier>() is Barier) { collider.GetComponent<Barier>().Recievedmg(); Debug.Log("Hello", gameObject); } // тоже не работает
    }
}
