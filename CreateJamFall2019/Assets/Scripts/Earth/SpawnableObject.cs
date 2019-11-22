using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Earth", menuName = "Spawnable")]
public class SpawnableObject : ScriptableObject
{
    public string Name = "Temp";
    public float CoolDown = 2f;
    [FormerlySerializedAs("IsPhysics")] public bool SpawnOnPlanet = false;
    public GameObject Prefab;
}
