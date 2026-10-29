using UnityEngine;

[CreateAssetMenu(fileName = "FallingObjectData", menuName = "Scriptable Objects/Falling Objects/New Falling Object")]
public class FallingObjectData : ScriptableObject
{
    [SerializeField] private float _fallSpeed;
    [SerializeField] private int _points;
    [SerializeField] private int _spawnWeight;

    public float FallSpeed => _fallSpeed;
    public int Points => _points;
    public int SpawnWeight => _spawnWeight;
}
