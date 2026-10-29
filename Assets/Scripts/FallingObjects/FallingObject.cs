using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private FallingObjectData _fallingObjectData;
    public FallingObjectData Data => _fallingObjectData;

    private void Update()
    {
        transform.Translate(_fallingObjectData.FallSpeed * Time.deltaTime * Vector2.down, Space.World);
    }
}
