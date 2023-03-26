using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasivgroupEneme : MonoBehaviour
{
     public Eneme ship1;
     public Eneme ship2;
     public Eneme ship3; 
     public Eneme ship4;
     public Eneme ship5;
     public Eneme ship6;
     public Eneme ship7;
     public Eneme ship8;
     public Eneme ship9;
     public Eneme ship10;
     public Eneme ship11;
     public Eneme ship12;
     public bool isAlive = true;
     
    private float speed = 0.1f;
    private System.Random randomGenerator = new System.Random();
    private List<Eneme> Ships = new List<Eneme>();
    private bool MoveLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        Ships.Add(ship1);
        Ships.Add(ship2);
        Ships.Add(ship3);
        Ships.Add(ship4);
        Ships.Add(ship5);
        Ships.Add(ship7);
        Ships.Add(ship8);
        Ships.Add(ship9);
        Ships.Add(ship10);
        Ships.Add(ship11);
        Ships.Add(ship12);

        InvokeRepeating("groupTimetoShoot",2.0f,0.01f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ships.RemoveAll(item => item == null);
        Ships.RemoveAll(item => item.health <= 0);
        if (Ships.Count == 0) 
        {
            isAlive = false;
            CancelInvoke();
            return;
        }
        if (MoveLeft == true)
        {
            float minX = MinX();
            float stepX = minX - speed;
            if(stepX < -12)
            {
                MoveLeft = false;
            }else
            {
                transform.position = new Vector3(transform.position.x - speed,transform.position.y,0);
            }
        }else 
        {
           float maxX = MaxX();
           float stepX = maxX + speed;
           if(stepX > 12)
           {
             MoveLeft = true;
           }else
           {
                transform.position = new Vector3(transform.position.x + speed,transform.position.y,0);
           }
        }
    }

    float MaxX()
    {
        int i = 0;
        float max = float.MinValue;
        while(i < Ships.Count)
        {
            if(Ships[i].transform.position.x > max)
            {
                max = Ships[i].transform.position.x;
            }
            i++;
        }
        return max;
    }

    float MinX()
    {
        int i = 0;
        float min = float.MaxValue;
        while(i < Ships.Count)
        {
            if(Ships[i].transform.position.x < min)
            {
                min = Ships[i].transform.position.x;
            }
            i++;
        }
        return min;  
    }
    
    void groupTimetoShoot()
    {
        int randomINdex = randomGenerator.Next(Ships.Count);
        Ships[randomINdex].Shoot();
    }
}   
