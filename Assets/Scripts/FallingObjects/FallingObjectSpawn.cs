using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fallingObject;
    private float _minX;
    private float _maxX;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Camera mainCamera = Camera.main;
        (_minX, _maxX) = GetHorizontalBounds(mainCamera);
        foreach (var item in _fallingObject)
        {
            float randomPositionX = Random.Range(_minX, _maxX);
            Vector3 spawnPosition = new Vector3(randomPositionX, transform.position.y, 0f);
            Instantiate(item, spawnPosition, Quaternion.identity);
        }
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
