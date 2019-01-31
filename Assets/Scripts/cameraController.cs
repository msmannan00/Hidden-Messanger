using UnityEngine;
using UnityEngine.UI;

public class cameraController : MonoBehaviour
{
    public WebCamTexture mCamera = null;
    public RawImage rawimage;

    // Use this for initialization
    void Start()
    {
        WebCamTexture webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}