using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlacksmith : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WorkDelay()
    {
        

        yield return new WaitForSeconds(2);
    }
}
