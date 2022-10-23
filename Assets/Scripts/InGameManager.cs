using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    

    public void NoteGen(int lane, int note, int bit, int index) { //96beat deriv.
        if (!((((lane == 2) || (lane == 3)) && ((1 <= note) && (note <= 4))) && (((lane == 1) || (lane == 4)) && ((0 <= note) && (note <= 1))))) {
            return;
        }
        
        

    }

    public void SamplePattern() {

    }
}
