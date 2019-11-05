using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject speedpower;
    public static int powerupCnt = 1;
    public bool isOver;
    public GameObject snakehead;
    public GameObject lifepower;
    public static List<GameObject> Sp = new List<GameObject>();
    public static List<GameObject> Li = new List<GameObject>();
    void Start()
    {
        InvokeRepeating("Spawn", 10, 10);
    }
    void Spawn()
    {
        if (powerupCnt < 3 && Player.isPlayerAlive == true)
        {
            int i = Random.Range(1, 5);
            if (i == 1 || i == 3)
            {
                {
                    float x;
                    float y;
                    do
                    {
                        isOver = false;
                        x = Random.Range(-8.6f, 8.7f) * 0.5f;
                        y = Random.Range(-3.5f, 5.3f) * 0.5f;
                        if (Vector3.Distance(new Vector3(x, y, 0), snakehead.transform.position) <= 1.174f)
                        {
                            isOver = true;
                            //Debug.Log("Cannot spawn, coinciding with snake");
                        }

                        for (int j = 0; j < Player.tails.Count; j++)
                        {
                            //Debug.Log("Checking for coincidence with tail");
                            if (Vector3.Distance(new Vector3(x, y, 0), Player.tails[j].transform.position) <= 1.174f)
                            {
                                isOver = true;
                                //Debug.Log("Cannot spawn, coinciding with tail");
                            }
                        }
                        for (int j = 0; j < FoodManager.apple.Count; j++)
                        {
                            if (Vector3.Distance(new Vector3(x, y, 0), FoodManager.apple[j].transform.position) <= 2.174f)
                            {
                                isOver = true;
                                Debug.Log("Cannot spawn, coinciding with another apple");
                            }
                        }
                        for (int j = 0; j < Sp.Count; j++)
                        {
                            if (Vector3.Distance(new Vector3(x, y, 0), Sp[j].transform.position) <= 1.174f)
                            {
                                isOver = true;
                                //Debug.Log("Cannot spawn, coinciding with speedPowerup");
                            }
                        }
                        for (int j = 0; j < Li.Count; j++)
                        {
                            if (Vector3.Distance(new Vector3(x, y, 0), Li[j].transform.position) <= 1.174f)
                            {
                                isOver = true;
                                //Debug.Log("Cannot spawn, coinciding with lifePowerup");
                            }
                        }
                    } while (isOver == true);
                    GameObject newSprite = Instantiate<GameObject>(speedpower);
                    newSprite.transform.position = new Vector3(x, y, 0.0f);
                    Sp.Add(newSprite);
                    powerupCnt++;
                }
            }
            else
            {
                float x;
                float y;
                do
                {
                    isOver = false;
                    x = Random.Range(-8.6f, 8.7f) * 0.5f;
                    y = Random.Range(-3.5f, 5.3f) * 0.5f;
                    if (Vector3.Distance(new Vector3(x, y, 0), snakehead.transform.position) <= 1.174f)
                    {
                        isOver = true;
                        //Debug.Log("Cannot spawn, coinciding with snake");
                    }

                    for (int j = 0; j < Player.tails.Count; j++)
                    {
                        //Debug.Log("Checking for coincidence with tail");
                        if (Vector3.Distance(new Vector3(x, y, 0), Player.tails[j].transform.position) <= 1.174f)
                        {
                            isOver = true;
                            //Debug.Log("Cannot spawn, coinciding with tail");
                        }
                    }
                    for (int j = 0; j < FoodManager.apple.Count; j++)
                    {
                        if (Vector3.Distance(new Vector3(x, y, 0), FoodManager.apple[j].transform.position) <= 2.174f)
                        {
                            isOver = true;
                            Debug.Log("Cannot spawn, coinciding with another apple");
                        }
                    }
                    for (int j = 0; j < Sp.Count; j++)
                    {
                        if (Vector3.Distance(new Vector3(x, y, 0), Sp[j].transform.position) <= 1.174f)
                        {
                            isOver = true;
                            //Debug.Log("Cannot spawn, coinciding with speedPowerup");
                        }
                    }
                    for (int j = 0; j < Li.Count; j++)
                    {
                        if (Vector3.Distance(new Vector3(x, y, 0), Li[j].transform.position) <= 1.174f)
                        {
                            isOver = true;
                            //Debug.Log("Cannot spawn, coinciding with lifePowerup");
                        }
                    }
                } while (isOver == true);
                GameObject newSprite = Instantiate<GameObject>(lifepower);
                newSprite.transform.position = new Vector3(x, y, 0.0f);
                Li.Add(newSprite);
                powerupCnt++;
            } 
        }
    }
}
