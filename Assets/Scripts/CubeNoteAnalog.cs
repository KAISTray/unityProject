using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeNoteAnalog : MonoBehaviour
{
    [SerializeField]
    public Sprite NoteL;
    [SerializeField]
    public Sprite NoteR;
    [SerializeField]
    public int CurrentNum; // 0 : L, 1 : R
    [SerializeField]
    public GameObject curNote; // GameObject of current Note


    public void Clear() {
        CurrentNum = 0; //Left
        NoteUpdate();
    }

    public void NoteCW() {
        CurrentNum = 1 - CurrentNum;
        NoteUpdate();
    }

    public void NoteCCW() {
        CurrentNum = 1 - CurrentNum;
        NoteUpdate();
    }

    public void NoteUpdate() {
        if (CurrentNum == 1) {
            Image curImg = curNote.GetComponent<Image>();
            curImg.sprite = NoteR;
        } else {
            Image curImg = curNote.GetComponent<Image>();
            curImg.sprite = NoteL;
        }
    }

}
