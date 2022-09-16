using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_around : MonoBehaviour
{
    public float speed = 6f;
    private float minDistance;
    private Transform player;
    private Vector2 movePoint;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    

    void Start()
    {

        speed = Random.Range(5.4f, 6.2f);
        minDistance = Random.Range(4f, 10f);
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        movePoint = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));

        
  
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) <= minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            speed -= 0.1f*Time.deltaTime; 

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, movePoint) <= 0.2f)
            {
                movePoint = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
            }
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
