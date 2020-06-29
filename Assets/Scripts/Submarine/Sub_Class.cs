using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SubType { Explorer, Destroyer, Interceptor, Stealth }
[System.Serializable]
public class Sub_Class
{
    public SubType typeOf;
    public string name;
}
