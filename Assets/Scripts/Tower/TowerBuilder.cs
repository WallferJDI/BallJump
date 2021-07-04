using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _lvlCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _tower;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finisPlatform;
   
    private float _startAndFinisdAdditionalScale = 0.5f;
    public float TowerScaleY => _lvlCount / 2f + _startAndFinisdAdditionalScale + _additionalScale/2f;

    private void Start()
    {
        Build();
    }
    private void Build()
    {
       GameObject tower = Instantiate(_tower, transform);
        tower.transform.localScale = new Vector3(1,TowerScaleY, 1);

        Vector3 spawnPosition = tower.transform.position;
        spawnPosition.y += tower.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition,Quaternion.identity, tower.transform);
      
        for (int i = 0; i < _lvlCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)],ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0),tower.transform);
        }
        SpawnPlatform(_finisPlatform, ref spawnPosition, Quaternion.identity, tower.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition,Quaternion quaternion, Transform parent)
    {
        Instantiate(platform, spawnPosition, quaternion, parent);
        spawnPosition.y -= 1;
    }
}
