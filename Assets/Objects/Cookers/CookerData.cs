using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeOfCook{
    FRY,
    BAKE,
    NONE
}
public class CookerData : ItensPriority
{
    public typeOfCook type = typeOfCook.NONE;
    
}
