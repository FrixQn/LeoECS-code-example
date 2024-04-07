using ECSExample.Interfaces;
using System;
using UnityEngine;

namespace ECSExample.Configs
{
    [CreateAssetMenu(fileName = nameof(BalloonsSystemConfig), menuName = "Project/" + nameof(BalloonsSystemConfig))]
    internal class BalloonsSystemConfig : ScriptableObject, IBalloonsSystemConfig
    {
        [SerializeField] private GameObject[] _balloons = Array.Empty<GameObject>();
        [SerializeField, Range(1f, 10f)] private float _floatingSpeed;
        [SerializeField, Range(2f, 20f)] private float _floatingRange;

        [Header("Spawn configs")]
        [SerializeField] private Vector3 _center;
        [SerializeField] private Vector3 _extents;

        GameObject[] IBalloonsSystemConfig.Prefabs => _balloons;
        float IBalloonsSystemConfig.FloatingSpeed => _floatingSpeed;
        float IBalloonsSystemConfig.FloatingRange => _floatingRange;
        Vector3 IBalloonsSystemConfig.BoundsCenter => _center;
        Vector3 IBalloonsSystemConfig.SpawnExtents => _extents;

    }
}
