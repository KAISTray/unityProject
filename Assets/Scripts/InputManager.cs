using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
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
    

    
    void Update()
    {
        if (Input.GetKeyDown(A1)) {
            A1Judge.GetComponent<CubeNoteAnalog>().NoteCW();
        }
        if (Input.GetKeyDown(A2)) {
            A2Judge.GetComponent<CubeNoteAnalog>().NoteCW();
        }
        if (Input.GetKeyDown(D1CW)) {
            D1Judge.GetComponent<CubeNoteDigital>().NoteCW();
        }
        if (Input.GetKeyDown(D1CCW)) {
            D1Judge.GetComponent<CubeNoteDigital>().NoteCCW();
        }
        if (Input.GetKeyDown(D2CW)) {
            D2Judge.GetComponent<CubeNoteDigital>().NoteCW();
        }
        if (Input.GetKeyDown(D2CCW)) {
            D2Judge.GetComponent<CubeNoteDigital>().NoteCCW();
        }
    }
}
