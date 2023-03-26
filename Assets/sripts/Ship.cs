using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
  private AudioSource soundSource;
  private static float MAX_HEALTH = 200;
  private float speed = 0.3f;
  private int hitCount = 0;
  public float health = MAX_HEALTH;
   public GameObject hp1;
   public GameObject hp2;
   public GameObject hp3;
   public GameObject hp4;
   public GameObject bulletOriginal;
   public AudioClip shootSound;
  private List<GameObject> hpList = new List<GameObject>();

    void Start()
    {
      hpList.Add(hp1);
      hpList.Add(hp2);
      hpList.Add(hp3);
      hpList.Add(hp4);
      soundSource = GetComponent<AudioSource>();
      soundSource.Play();

    }
    // Update is called once per frame
    void Update()
    {
      bool KeyUp = Input.GetKey(KeyCode.Space);
      if (KeyUp) 
      {
        GameObject buiietClone;
        buiietClone = Instantiate(bulletOriginal);
        buiietClone.transform.position = transform.position;
        soundSource.PlayOneShot(shootSound);
      }
    }

    void FixedUpdate()
    {
      bool KeyUp = Input.GetKey(KeyCode.LeftArrow);
      if (KeyUp == true)
      {
          Vector3 objectPosistion = transform.position;
          objectPosistion.x -= speed;
          transform.position = objectPosistion;
      }    
       bool Key = Input.GetKey(KeyCode.RightArrow);
      if (Key == true)
      {
          Vector3 objectPosistion = transform.position;
          objectPosistion.x += speed;
          transform.position = objectPosistion;
      }
    }

     void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObgect = otherCollider.gameObject;
        ENEMEbullet enemeScript = otherObgect.GetComponent<ENEMEbullet>();
        if (enemeScript != null)
        {
            health -= enemeScript.damage;
            onHit();
            Destroy(otherObgect);
            if (health <= 0)
            {
              SceneManager.LoadSceneAsync(SceneID.LoseSceneID);
              Destroy(gameObject);
            }
        }
        HealthBonus bonusScript = otherObgect.GetComponent<HealthBonus>();
        if (bonusScript != null)
        {
          Destroy(otherObgect);
          RestoreHealth();
        }
    }
    void RestoreHealth()
    {
      print("Collecting health");
      health = MAX_HEALTH;
      hitCount = 0;
      foreach (GameObject currremItem in hpList)
      {
        currremItem.SetActive(true);
      }
    }

    public void onHit()
    {
      hpList[hitCount].SetActive(false);
      hitCount += 1;
    }
}
