using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class randomWordActivity : MonoBehaviour
{
    /*Public Game Objects*/
    public Text wordText;
    bool isGenerating = false;
    string[] wordList;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset txt = (TextAsset)Resources.Load("nounlist", typeof(TextAsset));
        string content = txt.text;
        Debug.Log("SHIT : " + content);
        wordList = content.Split(',');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        StopCoroutine(generateWords());
        wordText.DOColor(Color.white, 1);
        wordText.text = "Click Ask Buttton Below";
        isGenerating = false;
    }

    public void postProcess()
    {
        isGenerating = false;
    }


    private IEnumerator generateWords()
    {
        for (int e = 0; e < 50; e++)
        {
            wordText.text = wordList[Random.Range(0,4600)].ToString() + " " + wordList[Random.Range(0, 4600)].ToString() + " " + wordList[Random.Range(0, 4600)].ToString();
            yield return new WaitForSeconds(0.1f);
        }
        isGenerating = false;
        wordText.DOColor(Color.black, 1);
    }

    public void ask()
    {
        wordText.DOColor(Color.white, 1);
        if (!isGenerating)
        {
            isGenerating = true;

            StartCoroutine(generateWords());
        }
    }

}
