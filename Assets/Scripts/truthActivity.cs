using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class truthActivity : MonoBehaviour
{
    /*Public Game Objects*/
    Sequence _sequence1;
    public GameObject needle;
    public Text yesText;
    public Text noText;
    bool isRotating = false;

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
        yesText.DOColor(Color.white, 0.5f);
        noText.DOColor(Color.white, 0.5f);
        needle.transform.eulerAngles = new Vector3(0, 0, -180);
        _sequence1.Kill();
    }

    public void setTextColor()
    {
        float pos = needle.transform.eulerAngles.z;
        Debug.Log(pos);
        if(pos>180)
        {
            yesText.DOColor(Color.green, 1);
        }
        else
        {
            noText.DOColor(Color.green, 1);
        }
        isRotating = false;
    }

    public void ask()
    {
        if (!isRotating)
        {
            isRotating = true;
            yesText.DOColor(Color.white, 0.5f);
            noText.DOColor(Color.white, 0.5f);

            _sequence1 = DOTween.Sequence();
            _sequence1
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-90, -180)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-180, -270)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-90, -180)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-180, -270)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-90, -180)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-180, -270)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-90, -180)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-180, -270)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-90, -92)), 0.7f))
                .Append(needle.transform.DORotate(new Vector3(0, 0, Random.Range(-110, -250)), 1.5f))
                .OnComplete(() => setTextColor());
        }

    }

}
