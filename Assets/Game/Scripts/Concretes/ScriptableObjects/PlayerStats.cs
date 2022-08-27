using Game.Scripts.Abstracts.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts.Concretes.ScriptableObjects
{
    [CreateAssetMenu]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [SerializeField] private float _moveSpeed = 5f;
        public float MoveSpeed => _moveSpeed;
    }
}
