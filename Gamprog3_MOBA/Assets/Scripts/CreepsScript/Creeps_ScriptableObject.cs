using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Creeps", menuName = "Scriptable Object/Creeps" + "")]
public class Creeps_ScriptableObject : ScriptableObject
{
    public string creepName;
    public int maxHP;
    public int ATK;
    public int attackRange;
    public int moveSpeed;
    

}
