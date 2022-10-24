using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judgement : MonoBehaviour
{
    [SerializeField]
    public GameObject curJudge;
    [SerializeField]
    public GameObject curJudgeImg;

    [SerializeField]
    public Sprite alpha;
    [SerializeField]
    public Sprite beta;
    [SerializeField]
    public Sprite gamma;
    [SerializeField]
    public Sprite delta;
    [SerializeField]
    public Sprite miss;
    [SerializeField]
    public Sprite empty;


    //0 break, 1 Bad, 2 Soso, 3 Good, 4 Perfect
    public void Judge(int judge) {
        Image curImg = curJudgeImg.GetComponent<Image>();
        if (judge == 0) {
            curImg.sprite = miss;
        } else if (judge == 1) {
            curImg.sprite = delta;
        } else if (judge == 2) {
            curImg.sprite = gamma;
        } else if (judge == 3) {
            curImg.sprite = beta;
        } else if (judge == 4) {
            curImg.sprite = alpha;
        }
    }
}
