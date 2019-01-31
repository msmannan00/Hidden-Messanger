using UnityEngine;

public class sleepManager : MonoBehaviour
{
    public audioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        manager.stopBackground();
    }

    public void OnDisable()
    {
        manager.startBackground();
    }


}
