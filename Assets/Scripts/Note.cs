using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public int speed;
    public int lane; // 1, 4 as analog, 2, 3 as digital
    public int type; // 1, 2, 3, 4 as digital, 0, 1 as analog

    [SerializeField]
    public GameObject curNote;
    [SerializeField]
    public GameObject curNoteImg;
    

    [SerializeField]
    public Sprite Note1;
    [SerializeField]
    public Sprite Note2;
    [SerializeField]
    public Sprite Note3;
    [SerializeField]
    public Sprite Note4;
    [SerializeField]
    public Sprite NoteL;
    [SerializeField]
    public Sprite NoteR;

    public void setNoteImg(int lane, int type) {
        Image curImg = curNoteImg.GetComponent<Image>();
        if ((lane == 1) || (lane == 4)) { //analog
            if (type == 0) {
            curImg.sprite = NoteL;
            } else if (type == 1) {
            curImg.sprite = NoteR;
            }
        } else if ((lane == 2) || (lane == 3)) { //digital
            if (type == 1) {
                curImg.sprite = Note1;
            } else if (type == 2) {
                curImg.sprite = Note2;
            } else if (type == 3) {
                curImg.sprite = Note3;
            } else if (type == 4) {
                curImg.sprite = Note4;
            }
        }
    }

    void Update() {
        if (curNote.GetComponent<RectTransform>().position.y < -80.0f) {
            Destroy(curNote);
        }
    }
    void FixedUpdate()
    {
        Vector3 speedVec = new Vector3(0, speed, 0);
        curNote.GetComponent<RectTransform>().position += speedVec * 0.001f;

        
    }


}
