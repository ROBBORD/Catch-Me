using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_around2 : MonoBehaviour
{
    public float speed = 6f;
    private float minDistance;
    private Transform player;
    private Vector2 movePoint;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float fireTime;
    public GameObject bullet;
    

    void Start()
    {

        fireTime = Random.Range(1f, 3f);

        
  
    }
    void Update()
    {

        
        if(Time.time >= fireTime)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            fireTime = Time.time + Random.Range(2f, 6f);
        }
  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
        
        
    }
}
