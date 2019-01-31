using UnityEngine;

public class audioManager : MonoBehaviour
{
    //Public Game Objects
    public AudioSource[] source;

    //Private Variables
    int previousMusicIndex = -1;

    void Start()
    {
        Debug.Log("asdasdassad");
        startBackground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBackground()
    {
        playAudio(5);
    }

    public void stopBackground()
    {
        source[5].Stop();
    }

    public void playAudio(int index)
    {
        if (previousMusicIndex != -1)
        {
            source[previousMusicIndex].Stop();
        }
        previousMusicIndex = index;
        source[index].loop = true;
        source[index].Play();
    }
}
