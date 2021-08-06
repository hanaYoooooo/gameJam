using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Agent Stats",menuName = "Agent Stats")]
public class AgentStats : ScriptableObject
{
    public string _name;
    public float speed;
    public Material color;
}
