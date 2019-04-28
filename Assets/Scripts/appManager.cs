using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startDelay());
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(5);
        prefManager.sharedInstance().loadPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
