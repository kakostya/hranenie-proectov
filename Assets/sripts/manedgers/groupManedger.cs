using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupManedger : MonoBehaviour
{
    public GameObject firstGroupOriginal;
    
    public PasivgroupEneme CreateEnemeGroup()
    {
        GameObject newGroup = Instantiate(firstGroupOriginal);
        PasivgroupEneme group = newGroup.GetComponent<PasivgroupEneme>();
        return group;
    }
}
