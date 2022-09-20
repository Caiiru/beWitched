using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputs : MonoBehaviour
{
    public bool interactInput(){
        return Input.GetKeyDown(KeyCode.E);
    }
    public bool shootInput(){
        return Input.GetKeyDown(KeyCode.R);
    }
}
