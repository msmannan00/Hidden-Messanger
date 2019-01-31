using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class messageManager : MonoBehaviour
{
    /*Public Game Objects*/
    public InputField txt1;
    public InputField txt2;
    public InputField txt3;
    public Text response_text;
    public Image responseImage;

    /*Public Variables*/
    Boolean isMessageSend = false;

    void Start()
    {
    }

    /*Helper Methods*/
    public void validateForm()
    {
        if(!isMessageSend)
        {
            setMesaageStatus(true);

            if (txt1.text.Equals("") || txt2.text.Equals("") || txt3.text.Equals(""))
            {
                response_text.text = "You missed something in form above";
            }
            else
            {
                response_text.text = "Message sent to spirit world";
                sendMessage();
            }

            responseEnable();
            responseDisable();
        }
    }

    void sendMessage()
    {
        adManager.sharedInstance().showStaticAds();
        txt1.text = "";
        txt2.text = "";
        txt3.text = "";
        networkManager.sharedInstance().sendMessage(txt1.text, txt2.text, txt3.text, SystemInfo.deviceUniqueIdentifier);
    }

    public void setMesaageStatus(Boolean status)
    {
        isMessageSend = status;
    }

    /*Animations*/
    public void responseEnable()
    {
        Sequence _sequence1 = DOTween.Sequence();
        _sequence1
            .Append(responseImage.DOFade(1,1))
            .Join(response_text.DOFade(1, 1));
    }

    public void responseDisable()
    {
        Sequence _sequence2 = DOTween.Sequence();
        _sequence2.SetDelay(1.5f)
            .Append(responseImage.DOFade(0, 1))
            .Join(response_text.DOFade(0, 1))
            .OnComplete(() => setMesaageStatus(false));
    }
}