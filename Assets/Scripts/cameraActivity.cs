using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class cameraActivity : MonoBehaviour
{
    /*Public Game Objects*/
    public RawImage rawimage;
    public Image cameraFilter;
    WebCamTexture webcamTexture;
    bool isInitialized = false;

    /*Private Variables*/
    RawImage backupRawimage;
    Thread thread;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        StartCoroutine(initializeCamera(true));
    }

    private IEnumerator initializeCamera(bool status)
    {
        if(status)
        {
            yield return new WaitForSeconds(0.0f);
            if (!isInitialized)
            {
                backupRawimage = rawimage;
                isInitialized = true;
                webcamTexture = new WebCamTexture();
            }
            rawimage.texture = webcamTexture;
            rawimage.material.mainTexture = webcamTexture;
            webcamTexture.Play();
        }
    }

    void OnDisable()
    {
        webcamTexture.Stop();
        rawimage.texture = null;
        rawimage.material.mainTexture = null;
    }


}
