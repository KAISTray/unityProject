using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{

    [SerializeField]
    public GameObject notePrefab;
    [SerializeField]
    public GameObject noteParent;
    
    //1st bit always starts at height (speed) * 2.
    //index : 96beat standard. Therefore index must be (0 <= index < 96)
    //speed 10 = 80/s. 50 is standard, 100 is maximum
    public void NoteGen(float bpm, int speed, int lane, int note, int bit, int index) { //96beat deriv.
        
        float nx = -200 + (80 * lane);
        float ny = 8.0f * (bit + (index / 96.0f)) * (speed * 60 / bpm) + 8 * speed;
        Vector3 noteXY = new Vector3(nx, ny, 0);
        GameObject noteG = Instantiate(notePrefab, noteXY, Quaternion.identity) as GameObject;
        noteG.transform.SetParent(noteParent.transform, false);

        noteG.GetComponent<Note>().speed = -8 * speed;
        noteG.GetComponent<Note>().type = note;
        noteG.GetComponent<Note>().lane = lane;
        noteG.GetComponent<Note>().setNoteImg(lane, note);
        
    }

    public void SamplePattern() {
        float bpm = 150.0f;
        for (int i = 1; i<=10; i++) {
            NoteGen(bpm, 50, 1, (i % 2), (i * 2 - 1), 0);
            NoteGen(bpm, 50, 4, (i % 2), (i * 2), 0);
        }
    }

    void start() {
        Time.fixedDeltaTime = 0.0f;
    }

    public void startSong() {
        SamplePattern();
        Time.fixedDeltaTime = 0.001f;
    }
}
