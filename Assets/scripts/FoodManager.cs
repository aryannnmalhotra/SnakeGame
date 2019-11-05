using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject FoodSprite;
    public GameObject player;
    private int foodCnt = 1;
    private bool isOverlap=false;
    public static List<GameObject> apple = new List<GameObject>();
    // Start is called before the first frame update
    void FoodInstance()
    {
        if (foodCnt < 6 && Player.isPlayerAlive==true)
        {
            float x;
            float y;
            do
            {
                isOverlap = false;
                x = Random.Range(-8.6f, 8.7f) * 0.5f;
                y = Random.Range(-3.5f, 5.3f) * 0.5f;
                if (Vector3.Distance(new Vector3(x,y,0), player.transform.position)<=1.174f)
                { 
                    isOverlap = true;
                    //Debug.Log("Cannot spawn, coinciding with snake");
                }

                for (int i = 0; i < Player.tails.Count; i++)
                {
                    //Debug.Log("Checking for coincidence with tail");
                    if (Vector3.Distance(new Vector3(x,y,0), Player.tails[i].transform.position)<=1.174f)
                    { 
                        isOverlap = true;
                        //Debug.Log("Cannot spawn, coinciding with tail");
                    }
                }
                for (int i = 0; i < apple.Count; i++)
                {
                    if (Vector3.Distance(new Vector3(x, y, 0), apple[i].transform.position) <= 2.174f)
                    {
                        isOverlap = true;
                        Debug.Log("Cannot spawn, coinciding with another apple");
                    }
                }
                for (int j = 0; j < PowerupManager.Sp.Count; j++)
                {
                    if (Vector3.Distance(new Vector3(x, y, 0), PowerupManager.Sp[j].transform.position) <= 1.174f)
                    {
                        isOverlap = true;
                        //Debug.Log("Cannot spawn, coinciding with speedPowerup");
                    }
                }
                for (int j = 0; j < PowerupManager.Li.Count; j++)
                {
                    if (Vector3.Distance(new Vector3(x, y, 0), PowerupManager.Li[j].transform.position) <= 1.174f)
                    {
                        isOverlap = true;
                        //Debug.Log("Cannot spawn, coinciding with lifePowerup");
                    }
                }
            } while (isOverlap==true);
            GameObject newSprite = Instantiate<GameObject>(FoodSprite);
            newSprite.transform.position = new Vector3(x, y, 0.0f);
            apple.Add(newSprite);
            foodCnt++;
        }
    }
    void Start()
    {
        InvokeRepeating("FoodInstance", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            foodCnt--;
            for(int i = 0; i < apple.Count; i++)
            {
                if (apple[i] == collision.gameObject)
                {
                    apple.RemoveAt(i);
                    int j;
                    for ( j = i; j < apple.Count-1; j++)
                        apple[j] = apple[j + 1]; ;
                    
                }
            }
            Destroy(collision.gameObject);
        }

    }
}
