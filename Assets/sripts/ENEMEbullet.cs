using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
   


public class ENEMEbullet : MonoBehaviour
{
     private float speed = 0.3f;
        public int damage = 50;
    
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
    void Update()
    {
        
    }
}
