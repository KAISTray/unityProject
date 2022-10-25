using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public bool timerStarted = false;
    public ulong fTimer;
    public int speedSet = 400;

    public struct noteInfo {
        float bmp;
        int speed;
        int lane;
        int note;
        int bit;
        int index; //12
    }

    public Queue<GameObject> A1Lane = new Queue<GameObject>();
    public Queue<GameObject> D1Lane = new Queue<GameObject>();
    public Queue<GameObject> D2Lane = new Queue<GameObject>();
    public Queue<GameObject> A2Lane = new Queue<GameObject>();

    [SerializeField]
    public GameObject selfObj;
    [SerializeField]
    public GameObject notePrefab;
    [SerializeField]
    public GameObject noteParent;
    [SerializeField]
    public GameObject InputManager;
    [SerializeField]
    public GameObject AudioManager;
    
    //1st bit always starts at height (speed) * 2.
    //index : 96beat standard. Therefore index must be (0 <= index < 96)
    //speed 10 = 80/s. 50 is standard, 100 is maximum
    public void NoteGen(float bpm, int speed, int lane, int note, int bit, int index) { //12beat deriv.
        

        float nx = -200 + (80 * lane);
        float ny = 8.0f * (bit + (index / 12.0f)) * (speed * 60 / bpm) + 32 * speed;
        Vector3 noteXY = new Vector3(nx, ny, 0);
        GameObject noteG = Instantiate(notePrefab, noteXY, Quaternion.identity) as GameObject;
        noteG.transform.SetParent(noteParent.transform, false);

        noteG.GetComponent<Note>().speed = -8 * speed;
        noteG.GetComponent<Note>().type = note;
        noteG.GetComponent<Note>().lane = lane;
        noteG.GetComponent<Note>().setNoteImg(lane, note);
        noteG.GetComponent<Note>().inputManager = InputManager;
        noteG.GetComponent<Note>().InGameManager = selfObj;

        if (lane == 1) {
            A1Lane.Enqueue(noteG);
        } else if (lane == 2) {
            D1Lane.Enqueue(noteG);
        } else if (lane == 3) {
            D2Lane.Enqueue(noteG);
        } else if (lane == 4) {
            A2Lane.Enqueue(noteG);
        }
    }

    public void NoteOn(float bpm, int speed, int lane, int note, int bit, int index) {
        timerStarted = false;
    }
    
    public void SamplePattern() {
        float bpm = 150.0f;
        Time.fixedDeltaTime = 1 / (bpm * 12);
        for (int i = 1; i<=10; i++) {
            NoteGen(bpm, 50, 1, ((i) % 2), (i * 2 - 1), 0);
            NoteGen(bpm, 50, 4, ((i) % 2), (i * 2), 0);
        }
    }

    void start() {
        Time.fixedDeltaTime = 0.0f;
        fTimer = 0;
        timerStarted = false;
    }

    public void startSong() {
        A1Lane.Clear();
        A2Lane.Clear();
        D1Lane.Clear();
        D2Lane.Clear();

        NevermindT();
        
    }

    public void NevermindT() {
        float bpm = 142.0f;
        Time.fixedDeltaTime = 1 / (bpm * 12);
        NoteGen(bpm, speedSet, 1, 1, 12, 0);
        NoteGen(bpm, speedSet, 4, 1, 12, 0);
        NoteGen(bpm, speedSet, 2, 2, 12, 6);
        NoteGen(bpm, speedSet, 3, 2, 12, 9);
        NoteGen(bpm, speedSet, 1, 0, 13, 0);
        NoteGen(bpm, speedSet, 4, 0, 13, 0);

        NoteGen(bpm, speedSet, 1, 1, 14, 0);
        NoteGen(bpm, speedSet, 4, 1, 14, 0);
        NoteGen(bpm, speedSet, 3, 3, 14, 6);
        NoteGen(bpm, speedSet, 2, 3, 14, 9);
        NoteGen(bpm, speedSet, 1, 0, 15, 0);
        NoteGen(bpm, speedSet, 4, 0, 15, 0);

        NoteGen(bpm, speedSet, 1, 1, 16, 0);
        NoteGen(bpm, speedSet, 4, 1, 16, 0);
        NoteGen(bpm, speedSet, 2, 4, 16, 3);
        NoteGen(bpm, speedSet, 2, 1, 16, 6);
        NoteGen(bpm, speedSet, 2, 2, 16, 9);

        NoteGen(bpm, speedSet, 1, 0, 17, 0);
        NoteGen(bpm, speedSet, 4, 0, 17, 0);
        NoteGen(bpm, speedSet, 3, 4, 17, 6);

        NoteGen(bpm, speedSet, 1, 1, 18, 0);
        NoteGen(bpm, speedSet, 4, 1, 18, 0);
        NoteGen(bpm, speedSet, 3, 1, 18, 3);
        NoteGen(bpm, speedSet, 3, 2, 18, 6);
        NoteGen(bpm, speedSet, 3, 3, 18, 9);

        NoteGen(bpm, speedSet, 1, 0, 19, 0);
        NoteGen(bpm, speedSet, 4, 0, 19, 0);
        NoteGen(bpm, speedSet, 2, 3, 19, 6);

        NoteGen(bpm, speedSet, 1, 1, 20, 0);
        NoteGen(bpm, speedSet, 4, 1, 20, 0);
        NoteGen(bpm, speedSet, 1, 0, 20, 3);

        NoteGen(bpm, speedSet, 1, 1, 20, 9);
        NoteGen(bpm, speedSet, 4, 0, 20, 9);
        NoteGen(bpm, speedSet, 4, 1, 21, 0);

        NoteGen(bpm, speedSet, 1, 0, 21, 6);
        NoteGen(bpm, speedSet, 4, 0, 21, 6);
        NoteGen(bpm, speedSet, 1, 1, 21, 9);

        NoteGen(bpm, speedSet, 1, 0, 22, 3);
        NoteGen(bpm, speedSet, 4, 1, 22, 3);
        NoteGen(bpm, speedSet, 4, 0, 22, 6);

        NoteGen(bpm, speedSet, 1, 1, 23, 0);
        NoteGen(bpm, speedSet, 4, 1, 23, 3);
        NoteGen(bpm, speedSet, 1, 0, 23, 6);
        NoteGen(bpm, speedSet, 4, 0, 23, 9);

        NoteGen(bpm, speedSet, 1, 1, 24, 0);
        NoteGen(bpm, speedSet, 4, 1, 24, 0);
        NoteGen(bpm, speedSet, 1, 0, 24, 3);

        NoteGen(bpm, speedSet, 1, 1, 24, 9);
        NoteGen(bpm, speedSet, 4, 0, 24, 9);
        NoteGen(bpm, speedSet, 4, 1, 25, 0);

        NoteGen(bpm, speedSet, 1, 0, 25, 6);
        NoteGen(bpm, speedSet, 4, 0, 25, 6);
        NoteGen(bpm, speedSet, 1, 1, 25, 9);

        NoteGen(bpm, speedSet, 1, 0, 26, 3);
        NoteGen(bpm, speedSet, 4, 1, 26, 3);
        NoteGen(bpm, speedSet, 4, 0, 26, 6);

        NoteGen(bpm, speedSet, 1, 1, 27, 0);
        NoteGen(bpm, speedSet, 4, 1, 27, 3);
        NoteGen(bpm, speedSet, 1, 0, 27, 6);
        NoteGen(bpm, speedSet, 4, 0, 27, 9);

        Invoke("NevermindT1", 4.0f);
    }

    public void NevermindT1() {
        //music play code
        AudioManager.GetComponent<AudioManager>().playSong("Nevermind");
    }
}
