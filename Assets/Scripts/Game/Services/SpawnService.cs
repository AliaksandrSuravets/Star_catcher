using StarCatcher.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StarCatcher.Game.Services
{
    public class SpawnService : SingletonMonoBehaviour<SpawnService>
    {
        #region Variables

        [Header("Spawn celestial bodies")]
        [SerializeField] private GameObject[] _celestialBodie;
        [SerializeField] private float _spawnLengthCB;
        [SerializeField] private float _timeSpawnCB;

        [Header("Spawn pick up")]
        [SerializeField] private GameObject[] _pickUp;
        [SerializeField] private float _spawnLengthPU;
        [SerializeField] private float _timeSpawnPU;
        
        #endregion

        #region Properties

        public int AmountSpawn { get; private set; }

        #endregion

        #region Unity lifecycle

        public void Reset()
        {
            AmountSpawn = 0;
        }

        private void Start()
        {
            InvokeRepeating("StartSpawningCelestialBodies",1,_timeSpawnCB);
            InvokeRepeating("StartSpawningPickUp",5,_timeSpawnPU);
        }

        #endregion

        #region Private methods

        //private IEnumerator Spawn  ??????????????????????????????????
        private void Spawn(GameObject go, float length)  
        {
            if (GameService.Instance.IsGameOver)
            {
                return;
            }
            
            float randomX = Random.Range(-length, length);
            Vector3 posToSpawn = new Vector3(randomX, transform.position.y, 0);
            Instantiate(go, posToSpawn, Quaternion.identity);
            AmountSpawn++;
        }
        

        private void StartSpawningCelestialBodies()
        {
            Spawn(_celestialBodie[Random.Range(0, _celestialBodie.Length)], _spawnLengthCB);
        }

        private void StartSpawningPickUp()
        {
            Spawn(_pickUp[Random.Range(0, _pickUp.Length)], _spawnLengthPU);
        }

        #endregion
    }
}