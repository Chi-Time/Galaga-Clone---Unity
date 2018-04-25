using UnityEngine;
using Assets.Code.Enums;
using Assets.Code.Classes.Enemies;
using System.Linq;

namespace Assets.Code.Classes
{
    class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _MinSpawnDelay = 1.0f;
        [SerializeField] private float _MaxSpawnDelay = 1.75f;
        [SerializeField] private Enemy[] _EnemyPrefabs = null;
        [SerializeField] private Enemy[] _OrderedPrefabs = null;

        private void OrderPrefabs ()
        {
            // Order the enemy prefabs so that they're in a logical order.
            _EnemyPrefabs = _EnemyPrefabs.OrderBy (x => x.EnemyType).ToArray ();
        }

        private void Start ()
        {
            OrderPrefabs ();

            float spawnDelay = Random.Range (_MinSpawnDelay, _MaxSpawnDelay);
            Invoke ("Spawn", spawnDelay);
        }

        private void Spawn ()
        {
            // Get the amount of different enemy types specified in the EnemyTypes enum.
            int numberOfEnemyTypes = System.Enum.GetValues (typeof (EnemyTypes)).Length;
            var enemyType = (EnemyTypes)Random.Range (0, numberOfEnemyTypes);

            switch (enemyType)
            {
                case EnemyTypes.Meteor:
                    SpawnMeteor ();
                    break;
                case EnemyTypes.Snowflake:
                    SpawnSnowflakes ();
                    break;
                case EnemyTypes.Jelly:
                    SpawnJellies ();
                    break;
            }

            float spawnDelay = Random.Range (_MinSpawnDelay, _MaxSpawnDelay);
            Invoke ("Spawn", spawnDelay);
        }

        private void SpawnMeteor ()
        {
            int index = (int)EnemyTypes.Meteor;
            Instantiate (_EnemyPrefabs[index], new Vector3 (Random.Range (-9f, 9f), 15f, 0f), Quaternion.identity);
        }

        private void SpawnSnowflakes ()
        {
            int index = (int)EnemyTypes.Snowflake;
            float xSpawnPos = Random.Range (-9f, 9f);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos, 15f, 0f), Quaternion.identity);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos + 1f, 16f, 0f), Quaternion.identity);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos + 2f, 17f, 0f), Quaternion.identity);
        }

        private void SpawnJellies ()
        {
            int index = (int)EnemyTypes.Jelly;
            float xSpawnPos = Random.Range (-8f, 8f);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos, 15f, 0f), Quaternion.identity);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos + 1f, 14f, 0f), Quaternion.identity);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos - 1f, 14f, 0f), Quaternion.identity);
        }
    }
}
