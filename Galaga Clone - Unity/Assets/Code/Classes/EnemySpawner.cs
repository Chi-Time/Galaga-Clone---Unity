using UnityEngine;
using Assets.Code.Enums;
using Assets.Code.Classes.Enemies;
using System.Linq;

namespace Assets.Code.Classes
{
    class EnemySpawner : MonoBehaviour
    {
        [Tooltip ("The minimum delay between enemy spawns.")]
        [SerializeField] private float _MinSpawnDelay = 1.0f;
        [Tooltip ("The maximum delay between enemy spawns.")]
        [SerializeField] private float _MaxSpawnDelay = 1.75f;
        [Tooltip ("The height at which the enemies will spawn from.")]
        [SerializeField] private float _SpawnHeight = 20f;
        [Tooltip ("The enemy prefabs to be spawned.")]
        [SerializeField] private Enemy[] _EnemyPrefabs = null;

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
            int numberOfEnemyTypes = System.Enum.GetValues (typeof (EnemyType)).Length;
            var enemyType = (EnemyType)Random.Range (0, numberOfEnemyTypes);

            switch (enemyType)
            {
                case EnemyType.Meteor:
                    SpawnMeteor ();
                    break;
                case EnemyType.Snowflake:
                    SpawnSnowflakes ();
                    break;
                case EnemyType.Jelly:
                    SpawnJellies ();
                    break;
                case EnemyType.Terran:
                    SpawnTerran ();
                    break;
            }

            float spawnDelay = Random.Range (_MinSpawnDelay, _MaxSpawnDelay);
            Invoke ("Spawn", spawnDelay);
        }

        private void SpawnMeteor ()
        {
            int index = (int)EnemyType.Meteor;
            Instantiate (_EnemyPrefabs[index], new Vector3 (Random.Range (-9f, 9f), _SpawnHeight, 0f), _EnemyPrefabs[index].transform.rotation);
        }

        private void SpawnSnowflakes ()
        {
            int index = (int)EnemyType.Snowflake;
            float xSpawnPos = Random.Range (-8f, 8f);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos, _SpawnHeight, 0f), _EnemyPrefabs[index].transform.rotation);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos + 1.5f, _SpawnHeight + 2f, 0f), _EnemyPrefabs[index].transform.rotation);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos + 2.5f, _SpawnHeight + 4f, 0f), _EnemyPrefabs[index].transform.rotation);
        }

        private void SpawnJellies ()
        {
            int index = (int)EnemyType.Jelly;
            float xSpawnPos = Random.Range (-8f, 8f);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos, _SpawnHeight, 0f), _EnemyPrefabs[index].transform.rotation);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos + 1.5f, _SpawnHeight - 1.5f, 0f), _EnemyPrefabs[index].transform.rotation);
            Instantiate (_EnemyPrefabs[index], new Vector3 (xSpawnPos - 1.5f, _SpawnHeight - 1.5f, 0f), _EnemyPrefabs[index].transform.rotation);
        }

        private void SpawnTerran ()
        {
            int index = (int)EnemyType.Terran;
            Instantiate (_EnemyPrefabs[index], new Vector3 (Random.Range (-8.5f, 8.5f), _SpawnHeight, 0f), _EnemyPrefabs[index].transform.rotation);
        }
    }
}
