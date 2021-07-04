using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    bool move = false;
    bool movetoshop = false;

    [SerializeField]
    Transform[] nodes;

    [SerializeField]
    Transform playert;

    int count = 0;
    float movespeed = 0.01f;
    
    void Start()
    {
        
    }
    public void MoveToShop()
    {
        move = true;
        movetoshop = true;
        count = 0;
    }

    public void MoveToHome()
    {
        move = true;
        movetoshop = false;
        count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(move==true)
        {
            if(movetoshop)
            {
                playert.position = Vector2.MoveTowards(playert.position,nodes[count].position, movespeed);
                if(count==0)
                {
                    float dist = Vector2.Distance(playert.position, nodes[count].position);
                    if(dist<1)
                    {
                        count = 1;
                        
                    }
                }
                else
                {
                    float dist = Vector2.Distance(playert.position, nodes[count].position);
                    if (dist < 1)
                    {
                        move = false;
                        this.gameObject.GetComponent<GameController>().Startconvo(true);
                    }
                }
            }
            else
            {
                playert.position = Vector2.MoveTowards(playert.position, nodes[count].position, movespeed);
                if (count == 0)
                {
                    float dist = Vector2.Distance(playert.position, nodes[count].position);
                    if (dist < 1)
                    {
                        count = 2;
                    }
                }
                else
                {
                    float dist = Vector2.Distance(playert.position, nodes[count].position);
                    if (dist < 1)
                    {
                        move = false;
                    }
                }
            }
        }
    }
}
