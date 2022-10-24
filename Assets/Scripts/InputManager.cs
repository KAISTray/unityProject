using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    public GameObject InGameManager;
    [SerializeField]
    public GameObject JudgeManager;

    [SerializeField]
    public GameObject A1Judge;
    [SerializeField]
    public GameObject D1Judge;
    [SerializeField]
    public GameObject D2Judge;
    [SerializeField]
    public GameObject A2Judge;

    [SerializeField]
    public KeyCode A1;
    [SerializeField]
    public KeyCode A2;
    [SerializeField]
    public KeyCode D1CW;
    [SerializeField]
    public KeyCode D1CCW;
    [SerializeField]
    public KeyCode D2CW;
    [SerializeField]
    public KeyCode D2CCW;
    
    public float absG(float x) {
        if (x > 0) {
            return x;
        } else {
            return -x;
        }
    }

    public void JudgeF(float y, int speed, GameObject eliNote) {
        if (y < (0.32 * speed)) {
            JudgeManager.GetComponent<Judgement>().Judge(4);
        } else if (y < (0.48 * speed)) {
            JudgeManager.GetComponent<Judgement>().Judge(3);
        } else if (y < (0.64 * speed)) {
            JudgeManager.GetComponent<Judgement>().Judge(2);
        } else if (y < (0.80 * speed)) {
            JudgeManager.GetComponent<Judgement>().Judge(1);
        } else {
            JudgeManager.GetComponent<Judgement>().Judge(0);
        }
        
        Destroy(eliNote);
    }

    public bool ifJudge(float y, int speed, int typeC, int typeN) {
        return ((absG(y - 80) < (speed * 2.4f) && (typeC == typeN)) || (y < -0.8f * speed));
    }

    public bool isQueueEmpty(Queue<GameObject> q) {
        bool u = false;
        foreach (GameObject x in q) {
            u = true;
            break;
        }
        return u;
    }

    //판정 감지범위 : 300ms, Perfect 40ms, Good 60ms, Soso 80ms, Bad 100ms, Miss 300ms
    //400/s = 50[16, 24, 32, 40, 40+~120], [0.32, 0.48, 0.64, 0.80, 2.40]
    void Update()
    {
        if (Input.GetKeyDown(A1)) {
            A1Judge.GetComponent<CubeNoteAnalog>().NoteCW();

            if (isQueueEmpty(InGameManager.GetComponent<InGameManager>().A1Lane)) {
                GameObject A1Last = InGameManager.GetComponent<InGameManager>().A1Lane.Peek();
                int typeC = A1Judge.GetComponent<CubeNoteAnalog>().CurrentNum;
                float y = A1Last.GetComponent<RectTransform>().position.y;
                int typeN = A1Last.GetComponent<Note>().type;
                int speed = A1Last.GetComponent<Note>().speed / -8;
                if (ifJudge(y, speed, typeC, typeN)) {
                    JudgeF(absG(y - 80), speed, A1Last);
                    InGameManager.GetComponent<InGameManager>().A1Lane.Dequeue();
                }
            }
        } 
        
        if (Input.GetKeyDown(A2)) {
            A2Judge.GetComponent<CubeNoteAnalog>().NoteCW();

            if (isQueueEmpty(InGameManager.GetComponent<InGameManager>().A2Lane)) {
                GameObject A2Last = InGameManager.GetComponent<InGameManager>().A2Lane.Peek();
                int typeC = A2Judge.GetComponent<CubeNoteAnalog>().CurrentNum;
                float y = A2Last.GetComponent<RectTransform>().position.y;
                int typeN = A2Last.GetComponent<Note>().type;
                int speed = A2Last.GetComponent<Note>().speed / -8;
                if (ifJudge(y, speed, typeC, typeN)) {
                    JudgeF(absG(y - 80), speed, A2Last);
                    InGameManager.GetComponent<InGameManager>().A2Lane.Dequeue();
                }
            }
        }
        if (Input.GetKeyDown(D1CW)) {
            D1Judge.GetComponent<CubeNoteDigital>().NoteCW();

            if (isQueueEmpty(InGameManager.GetComponent<InGameManager>().D1Lane)) {
                GameObject D1Last = InGameManager.GetComponent<InGameManager>().D1Lane.Peek();
                int typeC = D1Judge.GetComponent<CubeNoteDigital>().CurrentNum;
                float y = D1Last.GetComponent<RectTransform>().position.y;
                int typeN = D1Last.GetComponent<Note>().type;
                int speed = D1Last.GetComponent<Note>().speed / -8;
                if (ifJudge(y, speed, typeC, typeN)) {
                    JudgeF(absG(y - 80), speed, D1Last);
                    InGameManager.GetComponent<InGameManager>().D1Lane.Dequeue();
                }
            }
        }
        if (Input.GetKeyDown(D1CCW)) {
            D1Judge.GetComponent<CubeNoteDigital>().NoteCCW();

            if (isQueueEmpty(InGameManager.GetComponent<InGameManager>().D1Lane)) {
                GameObject D1Last = InGameManager.GetComponent<InGameManager>().D1Lane.Peek();
                int typeC = D1Judge.GetComponent<CubeNoteDigital>().CurrentNum;
                float y = D1Last.GetComponent<RectTransform>().position.y;
                int typeN = D1Last.GetComponent<Note>().type;
                int speed = D1Last.GetComponent<Note>().speed / -8;
                if (ifJudge(y, speed, typeC, typeN)) {
                    JudgeF(absG(y - 80), speed, D1Last);
                    InGameManager.GetComponent<InGameManager>().D1Lane.Dequeue();
                }
            }
        }
        if (Input.GetKeyDown(D2CW)) {
            D2Judge.GetComponent<CubeNoteDigital>().NoteCW();

            if (isQueueEmpty(InGameManager.GetComponent<InGameManager>().D2Lane)) {
                GameObject D2Last = InGameManager.GetComponent<InGameManager>().D2Lane.Peek();
                int typeC = D2Judge.GetComponent<CubeNoteDigital>().CurrentNum;
                float y = D2Last.GetComponent<RectTransform>().position.y;
                int typeN = D2Last.GetComponent<Note>().type;
                int speed = D2Last.GetComponent<Note>().speed / -8;
                if (ifJudge(y, speed, typeC, typeN)) {
                    JudgeF(absG(y - 80), speed, D2Last);
                    InGameManager.GetComponent<InGameManager>().D2Lane.Dequeue();
                }
            }
        }
        if (Input.GetKeyDown(D2CCW)) {
            D2Judge.GetComponent<CubeNoteDigital>().NoteCCW();

            if (isQueueEmpty(InGameManager.GetComponent<InGameManager>().D2Lane)) {
                GameObject D2Last = InGameManager.GetComponent<InGameManager>().D2Lane.Peek();
                int typeC = D2Judge.GetComponent<CubeNoteDigital>().CurrentNum;
                float y = D2Last.GetComponent<RectTransform>().position.y;
                int typeN = D2Last.GetComponent<Note>().type;
                int speed = D2Last.GetComponent<Note>().speed / -8;
                if (ifJudge(y, speed, typeC, typeN)) {
                    JudgeF(absG(y - 80), speed, D2Last);
                    InGameManager.GetComponent<InGameManager>().D2Lane.Dequeue();
                }
            }
        }
    }
}
