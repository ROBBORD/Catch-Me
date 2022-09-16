using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class spawn_in_point : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public float spawnTime1 = 3.3f;
    public float spawnTime2 = 7f;
    public float maxX = 23;
    public float minX =-25;
    public float maxY =9;
    public float minY =-17;
    public TextMeshProUGUI text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn1", 5f, spawnTime1);
        InvokeRepeating("Spawn2", 10f, spawnTime2);
    }

    // Update is called once per frame

    void Spawn1()
    {
        player.GetComponent<Player_move>().enemy_num += 1 ;
        text.text = "" + player.GetComponent<Player_move>().enemy_num;
        Instantiate(enemy1, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
    }
    void Spawn2()
    {
        player.GetComponent<Player_move>().enemy_num += 1 ;
        text.text = "" + player.GetComponent<Player_move>().enemy_num;
        Instantiate(enemy2, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
    }
}
