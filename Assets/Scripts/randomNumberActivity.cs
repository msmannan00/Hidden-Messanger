using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;
using System.Collections;

public class randomNumberActivity : MonoBehaviour
{
    /*Public Game Objects*/
    public Text numberText;
    bool isGenerating = false;

    /*Public Variables*/
    Thread thread;

    void OnDisable()
    {
        StopCoroutine(generateNumbers());
        numberText.DOColor(Color.white, 1);
        numberText.text = "Click Ask Buttton Below";
        isGenerating = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void postProcess()
    {
        isGenerating = false;
    }


    private IEnumerator generateNumbers()
    {
        for (int e = 0; e < 50; e++)
        {
            numberText.text = Random.Range(100000, 999999).ToString();
            yield return new WaitForSeconds(0.1f);
        }
        isGenerating = false;
        numberText.DOColor(Color.black, 1);
    }

    public void ask()
    {
        numberText.DOColor(Color.white, 1);
        if (!isGenerating)
        {
            isGenerating = true;

            StartCoroutine(generateNumbers());
        }
    }
}
