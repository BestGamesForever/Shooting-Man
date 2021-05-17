using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string prefabName;
    [Range(1,6)]
    public int numberOfPrefabsToCreate;
    [Range(20, 150)]
    public int numberOfTotalPrefabs;
    [Range(1, 6)]
    public int Speed;
    public Vector3[] spawnPoints;

}