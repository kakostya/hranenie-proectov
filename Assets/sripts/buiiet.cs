using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buiiet : MonoBehaviour
{
        private float speed = 0.2f;
        public int damage = 100;
  
    void FixedUpdate()
    {
       Vector3 objectPosistion = transform.position;
       objectPosistion.y += speed;
       transform.position = objectPosistion;
       if(ScreenHelper.IsPositionOnScreen(transform.position) == false) 
       {
            Destroy(gameObject);
       }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObgect = otherCollider.gameObject;
        Eneme enemeScript = otherObgect.GetComponent<Eneme>();
        if (enemeScript != null)
        {
            enemeScript.health -= damage;
            Destroy(gameObject);
            if (enemeScript.health <= 0)
            {
                enemeScript.DestroyEneme();
            }
        }
    }
}
