using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    #region Exposed
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _particleSpeed;
    [SerializeField] private float _spawnerRadius;
    [SerializeField] private float _nextSpawnTime;
    [SerializeField] private GameObject _particlePrefab;

    #endregion

    #region Unity Lifecycle
    void Start()
    {

    }

    void Update()
    {
        if(Time.timeSinceLevelLoad > _nextSpawnTime)
        {
            GameObject newParticle = SpawnParticle();

            LaunchParticle(newParticle);

            _nextSpawnTime = Time.timeSinceLevelLoad + _spawnDelay;

        }
    }
    #endregion

    #region Methodes

    private GameObject SpawnParticle()
    {
        GameObject particle = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
        return particle;

    }

    private void LaunchParticle(GameObject particle)
    {
        Rigidbody2D rigidbody = particle.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.right * _particleSpeed;
    }


    #endregion

    #region Private & Protected
    #endregion
}
