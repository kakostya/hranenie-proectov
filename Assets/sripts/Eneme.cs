using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Eneme : MonoBehaviour
{
    public int health = 10;
    public GameObject bulletOriginal;
    public GameObject hpBonusOriginal;
     public Animator spriteAmimator;
     private System.Random randomGenerator = new System.Random();
     private AudioSource soundSource;
     public AudioClip soundBoom;
     public void Start()
     {
        soundSource = GetComponent<AudioSource>();
     }
    public void Shoot()
    {
        GameObject buiietclon = Instantiate(bulletOriginal);
        buiietclon.transform.position = transform.position;
    }
    public void DestroyEneme()
    {
        transform.parent = null;
        spriteAmimator.SetBool("ISdead",true);
        soundSource.PlayOneShot(soundBoom);

    }


    public void OnDestroyAnimatorEnd()
    {
        double hpPercent = randomGenerator.NextDouble();
        if(hpPercent > 0.5)
        {
        GameObject newHPBonus = Instantiate(hpBonusOriginal);
        newHPBonus.transform.position=transform.position;
        } 
        Destroy(gameObject);
    }
}

