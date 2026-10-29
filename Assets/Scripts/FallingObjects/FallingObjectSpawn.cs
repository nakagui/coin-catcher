using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fallingObject;
    [SerializeField] private float _spawnInterval = 1f;
    private float _minX;
    private float _maxX;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void Spawn()
    {
        Camera mainCamera = Camera.main;
        (_minX, _maxX) = GetHorizontalBounds(mainCamera);

        int randomIndex = Random.Range(0, _fallingObject.Count);
        GameObject selectedObject = _fallingObject[randomIndex];
        SpriteRenderer selectedObjectSprite = selectedObject.GetComponent<SpriteRenderer>();
        float objectSpriteHalthWidth = selectedObjectSprite.sprite.bounds.extents.x;
        float randomPositionX = Random.Range(
            _minX + objectSpriteHalthWidth,
            _maxX - objectSpriteHalthWidth
        );
        Vector3 spawnPosition = new(randomPositionX, transform.position.y, 0f);
        Instantiate(selectedObject, spawnPosition, Quaternion.identity);
    }

    private float GetHalthWidthScreen(float aspect, float ortographicSize)
    {
        /*
            aspect = width / height => width = aspect * height
            ortographicSize = height / 2 => height = ortographicSize * 2

            width = aspect * ortographicSize * 2 =>
            => width / 2 = aspect * ortographicSize
        */
        float halthWidth = aspect * ortographicSize;
        return halthWidth;
    }

    private (float minX, float maxX) GetHorizontalBounds(Camera camera)
    {
        float halthWidth = GetHalthWidthScreen(
            camera.aspect,
            camera.orthographicSize
        );
        float minX = camera.transform.position.x - halthWidth;
        float maxX = camera.transform.position.x + halthWidth;
        return (minX, maxX);
    }
}
