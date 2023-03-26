using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class HealthBonus : MonoBehaviour
{
    private float speed = 0.01f;
     void FixedUpdate()
    {
       Vector3 objectPosistion = transform.position;
       objectPosistion.y -= speed;
       transform.position = objectPosistion;
       if(ScreenHelper.IsPositionOnScreen(transform.position) == false) 
       {
            Destroy(gameObject);
       }
    }
}
