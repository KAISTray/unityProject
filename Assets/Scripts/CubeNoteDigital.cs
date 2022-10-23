using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeNoteDigital : MonoBehaviour
{
    [SerializeField]
    public Sprite Note1;
    [SerializeField]
    public Sprite Note2;
    [SerializeField]
    public Sprite Note3;
    [SerializeField]
    public Sprite Note4;
    [SerializeField]
    public int CurrentNum; // 1, 2, 3, 4
    [SerializeField]
    public GameObject curNote; // GameObject of current Note


    public void Clear() {
        CurrentNum = 1; // LU
        NoteUpdate();
    }

    public void NoteCW() {
        CurrentNum = (((CurrentNum - 1) + 1) % 4) + 1;
        NoteUpdate();
    }

    public void NoteCCW() {
        CurrentNum = (((CurrentNum - 1) - 1) % 4) + 1;
        if (CurrentNum == 0) {
            CurrentNum = 4;
        }
        if (CurrentNum == 5) {
            CurrentNum = 1;
        }
        NoteUpdate();
    }

    public void NoteUpdate() {
        if (CurrentNum == 1) {
            Image curImg = curNote.GetComponent<Image>();
            curImg.sprite = Note1;
        } else if (CurrentNum == 2) {
            Image curImg = curNote.GetComponent<Image>();
            curImg.sprite = Note2;
        } else if (CurrentNum == 3) {
            Image curImg = curNote.GetComponent<Image>();
            curImg.sprite = Note3;
        } else if (CurrentNum == 4) {
            Image curImg = curNote.GetComponent<Image>();
            curImg.sprite = Note4;
        }
    }
}
