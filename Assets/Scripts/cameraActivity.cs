using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class cameraActivity : MonoBehaviour
{
    /*Public Game Objects*/
    public RawImage rawimage;
    public Image cameraFilter;
    public RectTransform parentTransform;

    /*Private Variables*/
    bool isInitialized = false;
    WebCamTexture webcamTexture;
    RawImage backupRawimage;
    Thread thread;
    Quaternion baseRotation;

    // Start is called before the first frame update
    void Start()
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
            RectTransform transform = rawimage.rectTransform;
            float width = parentTransform.rect.width;
            float height = parentTransform.rect.height;

            transform.sizeDelta = new Vector2(height, width);

            webcamTexture.Play();
        }
    }

    void Update()
    {
    }

    void OnDisable()
    {
        webcamTexture.Stop();

        rawimage.texture = null;
    }


}
