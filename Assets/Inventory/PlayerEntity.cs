using Entities;
using UnityEngine;

namespace Game
{
    public class PlayerEntity : MonoEntityBase
    {
        [SerializeField] private PlayerModel _playerModel;

        public PlayerEntity()
        {
            Add(new ComponentEquipItem());
            Add(new ComponentTakeOffItem());
        }
    }
}