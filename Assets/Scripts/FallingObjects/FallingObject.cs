using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private FallingObjectData _fallingObjectData;
    private float _minY;
    private ScoreManager _scoreManager;
    public FallingObjectData Data => _fallingObjectData;

    public void Initialize(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    private void Awake()
    {
        Camera mainCamera = Camera.main;
        _minY = -mainCamera.orthographicSize;
    }

    private void Update()
    {
        transform.Translate(
            _fallingObjectData.FallSpeed * Time.deltaTime * Vector2.down,
            Space.World
        );

        if (transform.position.y < _minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _scoreManager.UpdateScore(_fallingObjectData.Points);
            Destroy(gameObject);
        }
    }
}
