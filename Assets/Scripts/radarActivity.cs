using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;

public class radarActivity: MonoBehaviour
{
    /*Public Game Objects*/
    public Image radar;
    public Image radarBar;
    bool isGenerating = false;

    /*Public Variables*/
    Thread thread;
    Sequence _sequence1;
    Sequence _sequence2;

    // Start is called before the first frame update
    void Start()
    {
        ask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        generateNumbers();
    }

    void OnDisable()
    {
        isGenerating = false;
        _sequence1.Kill();
        _sequence2.Kill();
    }

    public void postProcess()
    {
        isGenerating = false;
    }


    private void generateNumbers()
    {
        _sequence1 = DOTween.Sequence();
        _sequence1
            .SetDelay(0.8f)
            .Append(radar.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f))
            .Join(radar.DOFade(0,1f))
            .SetLoops(-1);

        _sequence2 = DOTween.Sequence();
        _sequence2
            .Append(radarBar.transform.DOBlendableRotateBy(new Vector3(0, 0, -360), 3f, RotateMode.FastBeyond360).SetEase(Ease.Linear))
            .SetLoops(-1);

    }

    public void ask()
    {
        if (!isGenerating)
        {
            generateNumbers();
        }
    }
}
