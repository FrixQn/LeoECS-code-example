using ECSExample.Interfaces;
using UnityEngine;

namespace ECSExample.Configs
{
    [CreateAssetMenu(fileName = nameof(PhysicsConfig), menuName = "Project/" + nameof(PhysicsConfig))]
    internal class PhysicsConfig : ScriptableObject, IPhysicsConfig
    {
        [SerializeField] private Vector3 _gravity;

        Vector3 IPhysicsConfig.Gravity => _gravity;
    }
}
