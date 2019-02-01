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
    Quaternion baseRotation;

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

                // Checks how many and which cameras are available on the device
                for (int cameraIndex = 0; cameraIndex < WebCamTexture.devices.Length; cameraIndex++)
                {
                    // We want the back camera
                    if (!WebCamTexture.devices[cameraIndex].isFrontFacing)
                    {
                        webcamTexture = new WebCamTexture(cameraIndex, Screen.width, Screen.height);
                        baseRotation = rawimage.transform.rotation;
                    }

                }
            }
            rawimage.texture = webcamTexture;
            int width = Screen.width - (10 / Screen.width) * 100;
            float prevRect = rawimage.rectTransform.position.y;
            RectTransform transform = rawimage.rectTransform;
            transform.sizeDelta = new Vector2(width, width);
            prevRect = prevRect - width;
            transform.position = new Vector3(transform.position.x, transform.position.y + prevRect, transform.position.z);

            webcamTexture.Play();
        }
    }

    void OnDisable()
    {
        webcamTexture.Stop();

        rawimage.texture = null;
    }


}
