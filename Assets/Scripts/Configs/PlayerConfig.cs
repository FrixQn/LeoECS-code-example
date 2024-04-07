using ECSExample.Interfaces;
using UnityEngine;

namespace ECSExample.Configs
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Project/" + nameof(PlayerConfig))]
    internal class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _sprintSpeed;
        [SerializeField] private GameObject _playerPrefab;
        public float Speed => _speed;
        public float SprintSpeed => _sprintSpeed;
        public GameObject PlayerPrefab => _playerPrefab;
    }
}
