using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_move : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject bullet_player;
    private Vector2 velocity;
    public float health = 100f;
    protected Joystick joystick;

    public int enemy_num = 14;
    public TextMeshProUGUI text;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        velocity.x = joystick.Horizontal;
        velocity.y = joystick.Vertical;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet_player, transform.position, Quaternion.identity);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + velocity * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemy_num--;
            if (enemy_num <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            text.text = "" + enemy_num;
            Destroy(collision.gameObject);
        }
       
    }


    
}
