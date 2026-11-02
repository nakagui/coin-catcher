using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{
    [SerializeField][Min(1)] private float _spawnInterval = 1f;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private List<GameObject> _fallingObjectPrefabs;
    private float _minX;
    private float _maxX;

    private void Awake()
    {
        Camera mainCamera = Camera.main;
        (_minX, _maxX) = GetHorizontalBounds(mainCamera);
    }

    private void Start()
    {
        if (_fallingObjectPrefabs == null || _fallingObjectPrefabs.Count == 0)
        {
            return;
        }

        StartCoroutine(SpawnContinuously());
    }

    private IEnumerator SpawnContinuously()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _fallingObjectPrefabs.Count);
        GameObject selectedPrefab = _fallingObjectPrefabs[randomIndex];
        SpriteRenderer selectedObjectSprite = selectedPrefab.GetComponent<SpriteRenderer>();
        float objectHalfWidth = selectedObjectSprite.sprite.bounds.extents.x
            * Mathf.Abs(selectedPrefab.transform.localScale.x);
        float randomPositionX = Random.Range(
            _minX + objectHalfWidth,
            _maxX - objectHalfWidth
        );
        Vector3 spawnPosition = new(randomPositionX, transform.position.y, 0f);
        GameObject spawnedObject = Instantiate(
            selectedPrefab,
            spawnPosition,
            Quaternion.identity
        );
        FallingObject fallingObject = spawnedObject.GetComponent<FallingObject>();
        fallingObject.Initialize(_scoreManager);
    }

    private float GetScreenHalfWidth(float aspect, float orthographicSize)
    {
        /*
            aspect = width / height => width = aspect * height
            orthographicSize = height / 2 => height = orthographicSize * 2

            width = aspect * orthographicSize * 2 =>
            => width / 2 = aspect * orthographicSize
        */
        float halfWidth = aspect * orthographicSize;
        return halfWidth;
    }

    private (float minX, float maxX) GetHorizontalBounds(Camera camera)
    {
        float halfWidth = GetScreenHalfWidth(
            camera.aspect,
            camera.orthographicSize
        );
        float minX = camera.transform.position.x - halfWidth;
        float maxX = camera.transform.position.x + halfWidth;
        return (minX, maxX);
    }
}
