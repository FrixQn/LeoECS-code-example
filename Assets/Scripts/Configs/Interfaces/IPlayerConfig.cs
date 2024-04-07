using UnityEngine;

namespace ECSExample.Interfaces
{
    public interface IPlayerConfig
    {
        public float Speed { get; }
        public float SprintSpeed { get; }
        public GameObject PlayerPrefab { get; }
    }
}
