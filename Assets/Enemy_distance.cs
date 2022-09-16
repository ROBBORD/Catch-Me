using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_distance : MonoBehaviour
{
    public float speed = 6f;
    private Vector2 velocity;




    public float fireTime = 3f;
    private float maxDistance;
    private float minDistance;
    public GameObject bullet;
    private Transform player;
    

    void Start()
    {
        maxDistance = Random.Range(5f, 15f);

        minDistance = Random.Range(0f, 5f);
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        
  
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) <= minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) >= maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = this.transform.position;
        }

        if(Time.time >= fireTime)
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
            fireTime = Time.time + 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ColorUtility.TryParseHtmlString("#1C9CFF", out Color color1);
            GetComponent<SpriteRenderer>().color = color1;
            GetComponent<Enemy_distance>().enabled = false;
        }
        
        
    }
}
