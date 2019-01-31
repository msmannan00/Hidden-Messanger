using UnityEngine;
using DG.Tweening;

public class tweenManager
{
    /*shared instances*/
    static tweenManager manager = new tweenManager();

    public static tweenManager sharedInstance()
    {
        return manager;
    }

    public void fade(GameObject[] objects,System.Type[] type)
    {
        Sequence _sequence2 = DOTween.Sequence();


        Sequence _sequence1 = DOTween.Sequence();
    }
}
