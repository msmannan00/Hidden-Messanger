using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class specialSymbolActivity: MonoBehaviour
{
    /*Public Game Objects*/
    public Image[] blocks;
    bool isGenerating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        StopCoroutine(generateSymbols());
        isGenerating = false;
        resetBlocks();
    }

    public void postProcess()
    {
        isGenerating = false;
    }

    public void resetBlocks()
    {
        for (int e = 0; e < blocks.Length-1; e++)
        {
            blocks[e].DOColor(Color.white, 0.5f);
        }
    }

    private IEnumerator generateSymbols()
    {
        yield return new WaitForSeconds(0f);
        for (int e = 0; e < 150; e++)
        {
            if(blocks[Random.Range(1, blocks.Length - 1)].color == Color.red)
            {
                blocks[Random.Range(1, blocks.Length - 1)].DOColor(Color.white, 0.5f);
            }
            else
            {
                blocks[Random.Range(1, blocks.Length - 1)].DOColor(Color.red, 0.5f);
            }
            yield return new WaitForSeconds(0.1f);
        }
        isGenerating = false;
    }

    public void ask()
    {
        if (!isGenerating)
        {
            resetBlocks();
            isGenerating = true;

            StartCoroutine(generateSymbols());
        }
    }

}
