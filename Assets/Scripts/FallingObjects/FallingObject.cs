using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private FallingObjectData _fallingObjectData;
    private float _minY;
    public FallingObjectData Data => _fallingObjectData;

    private void Awake()
    {
        Camera mainCamera = Camera.main;
        _minY = -mainCamera.orthographicSize;
    }

    private void Update()
    {
        transform.Translate(_fallingObjectData.FallSpeed * Time.deltaTime * Vector2.down, Space.World);

        if (transform.position.y < _minY)
        {
            Destroy(gameObject);
        }
    }
}
