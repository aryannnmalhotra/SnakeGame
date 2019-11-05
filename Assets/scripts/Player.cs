using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    public GameObject Tail;
    public static int lives=3;
    public GameObject FoodSprit;
    public static bool isPlayerAlive=true;
    public Text live;
    public Text tailll;
    public int tailsss = 0;
    public bool speedSpawn = false;
    private int speed = 1;
    public int scnt = 0;
    public Rigidbody2D rb;
    public static List<GameObject> tails = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right;
        //var sprite = GetComponent<SpriteRenderer>().sprite;
        //Debug.Log(GetComponent<SpriteRenderer>().sprite.rect.width);
        //Debug.Log(GetComponent<SpriteRenderer>().sprite.pixelsPerUnit);
        InvokeRepeating("Move", 0, 0.2f);
    }
    private void Move()
    {
        if (isPlayerAlive == true) 
        {
            if (speedSpawn == true)
                scnt++;
            if (scnt == 25)
            {
                speedSpawn = false;
                scnt = 0;
                speed = 1;
            }
            for(int k = 0; k < speed; k++) { 
           Vector2 prevPos = transform.position;
           Vector2 currentPos = prevPos + (direction * 0.5f);
           transform.position = currentPos;
                for (int i = 0; i < tails.Count; i++)
                {
                    var temp = prevPos;
                    prevPos = tails[i].transform.position;
                    tails[i].transform.position = temp;
                }
           }
        }
    }
    void Update()
    {
        live.text = lives.ToString();
        tailll.text = tailsss.ToString();
        if (isPlayerAlive==true)
        {
            if (Input.GetKeyDown(KeyCode.A)&&direction!=Vector2.right)
                direction = Vector2.left;
            if (Input.GetKeyDown(KeyCode.W)&&direction!=Vector2.down)
                direction = Vector2.up;
            if (Input.GetKeyDown(KeyCode.S)&&direction!=Vector2.up)
                direction = Vector2.down;
            if (Input.GetKeyDown(KeyCode.D)&&direction!=Vector2.left)
                direction = Vector2.right;
            
        }
        int p = tails.Count ;
        for(int i = 0; i < tails.Count; i++)
        {
            float a = tails[i].transform.position.x-0.25f;
            float b = tails[i].transform.position.x + 0.25f;
            float c = tails[i].transform.position.y - 0.25f;
            float d = tails[i].transform.position.y + 0.25f;
            if (rb.transform.position.x>=a&&rb.transform.position.x<=b&&rb.transform.position.y>=c&&rb.transform.position.y<=d)
            {
                for (int j = i; j <=tails.Count; j++)
                {

                    var gameObject = tails[j];
                    tails.RemoveAt(j);
                    //Debug.Log("Removed from list");
                    Destroy(gameObject);
                    //Debug.Log("Destroyed");
                    tailsss = tails.Count + 1;
                }
            }
        }


    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("upper") || collison.gameObject.CompareTag("left") || collison.gameObject.CompareTag("right") || collison.gameObject.CompareTag("lower"))
        {
            lives--;
            if (lives > 0)
                rb.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            else if (lives == 0)
            {
                isPlayerAlive = false;
                tails.Clear();
                PowerupManager.Sp.Clear();
                FoodManager.apple.Clear();
                PowerupManager.Li.Clear();
                SceneManager.LoadScene("GameOver");
              

            }
        }
        else if (collison.gameObject.CompareTag("apple"))
        {
            var tail = Instantiate(Tail) as GameObject;
            //Debug.Log("created");
            tailsss = tails.Count + 1;
            var prevPos = new Vector2(transform.position.x, transform.position.y);
            transform.position = prevPos + (direction * 0.5f);
            tail.transform.position = prevPos;
            tails.Insert(0, tail);

        }
        else if (collison.gameObject.CompareTag("speed"))
        {
            speedSpawn = true;
            PowerupManager.powerupCnt--;
            speed = 2;
            for (int i = 0; i < PowerupManager.Sp.Count; i++)
            {
                if (PowerupManager.Sp[i] == collison.gameObject)
                {
                    PowerupManager.Sp.RemoveAt(i);
                    Destroy(collison.gameObject);
                    int j;
                    for (j = i; j < PowerupManager.Sp.Count - 1; j++)
                        PowerupManager.Sp[j] = PowerupManager.Sp[j + 1];
                    
                }
            }
        }
        else if (collison.gameObject.CompareTag("lifepower"))
        {
            PowerupManager.powerupCnt--;
            if (lives!=3)
                lives++;
            for (int i = 0; i < PowerupManager.Li.Count; i++)
            {
                if (PowerupManager.Li[i] == collison.gameObject)
                {
                    PowerupManager.Li.RemoveAt(i);
                    Destroy(collison.gameObject);
                    int j;
                    for ( j = i; j < PowerupManager.Li.Count - 1; j++)
                        PowerupManager.Li[j] = PowerupManager.Li[j + 1]; ;
                    
                }
            }
        }

    }


}
