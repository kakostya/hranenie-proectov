using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMAnedger : MonoBehaviour
{
    private AudioSource musica;
    private groupManedger groupManedger;
    private PasivgroupEneme currentGroup;
    private int maxGroupCount = 1;
    private int destroyedGroup = 0;
    public void Start()
    {
        destroyedGroup = 0;
       groupManedger = GetComponent<groupManedger>();
       currentGroup = groupManedger.CreateEnemeGroup();
       musica = GetComponent<AudioSource>();
      musica.Play();

    }

    public void Update()
    {
        if (currentGroup.isAlive == false) 
        {
            Destroy(currentGroup);
            destroyedGroup += 1;
            if (destroyedGroup == maxGroupCount)
            {
                SceneManager.LoadSceneAsync(SceneID.WinSceneID);
            }else
            {
                 currentGroup = groupManedger.CreateEnemeGroup();
            } 
        }
    }
}
