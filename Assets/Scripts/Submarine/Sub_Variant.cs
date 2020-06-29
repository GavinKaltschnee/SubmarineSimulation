using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(fileName = "SubType", menuName = "Submarine Data/Type", order = 0)]
public class Sub_Variant : ScriptableObject
{
    public Sub_Class SubData;
    public float MoveSpeed;
    public float TurnSpeed;
    [Range(0,1)]public float DiveSpeed;
    public float Mass;
    public int AmmoCount;
    public float ReloadTimer;
}
