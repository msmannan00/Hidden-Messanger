using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class sceneManager : MonoBehaviour {

    /*Public Game Objects*/
    public Button[] gridButtons;
    public GameObject[] pages;
    public Image topFader;
    public GameObject splashScreen;

    /*Local Variables*/
    int selectedGridIndex = 0;

    void Start()
	{
        waitForSplash();
    }

    public void waitForSplash()
    {
        Sequence _sequence2 = DOTween.Sequence();
        _sequence2
            .SetDelay(3)
            .OnComplete(() => closeSplash());

    }

    public void closeSplash()
    {
        splashScreen.SetActive(false);
    }

    public void showAd(int page)
    {
        if(page>5)
        {
            adManager.sharedInstance().showStaticAds();
        }
    }

    /*Helper Methods*/
    public void Load_Page(int page)
    {
        showAd(page);
        if (page==11)
        {
            topFader.DOFade(1f, 0.3f);
            Sequence _sequence2 = DOTween.Sequence();
            _sequence2
                .SetDelay(0.5f)
                .OnComplete(() => load_Open(page));
        }
        else
        {
            Sequence _sequence2 = DOTween.Sequence();
            _sequence2
                .Append(topFader.DOFade(0.87f, 0.3f))
                .OnComplete(() => load_Open(page));
        }
    }

    public void load_Open(int page)
    {
        resetOjbects();
        pages[page].gameObject.SetActive(true);

        if (page < 5)
        {
            ColorBlock oldGridColor = gridButtons[selectedGridIndex].colors;
            oldGridColor.normalColor = Color.white;

            ColorBlock newGridColor = gridButtons[page].colors;
            newGridColor.normalColor = new Color(114, 0, 0, 1);
            animateButtonClick(gridButtons[page]);
            selectedGridIndex = page;
        }
        topFader.DOFade(0, 0.3f);
    }

    public void resetOjbects()
    {
        for(int counter=0;counter< pages.Length;counter++)
        {
            pages[counter].SetActive(false);
        }
    }

    /*Animations*/
    public void animateButtonClick(Button button)
    {
        Sequence _sequence2 = DOTween.Sequence();
        _sequence2
            .Append(button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.15f))
            .Append(button.transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f));
    }

}
