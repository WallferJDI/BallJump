using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private int _lvlCount;
    [SerializeField] private float _additionalScale;
    private float _startAndFinisdAdditionalScale = 0.5f;
    private float _towerScaleY => _lvlCount / 2f + _startAndFinisdAdditionalScale + _additionalScale / 2f;

    [Header("Prefabs")]
    [SerializeField] private Tower _tower;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finisPlatform;   
    [SerializeField] private TowerBuilder _towerBuilder;


    private void Awake()
    {
        Build();
    }
    private void Build()
    {
       Tower tower = Instantiate(_tower, transform);
        tower.transform.localScale = new Vector3(1,_towerScaleY, 1);

        Vector3 spawnPosition = tower.transform.position;
        spawnPosition.y += tower.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition,Quaternion.identity, _towerBuilder.transform);
      
        for (int i = 0; i < _lvlCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)],ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), _towerBuilder.transform);
        }
        SpawnPlatform(_finisPlatform, ref spawnPosition, Quaternion.identity, _towerBuilder.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition,Quaternion quaternion, Transform parent)
    {
        
        Instantiate(platform, spawnPosition, quaternion, parent);
        spawnPosition.y -= 1;
    }
}
