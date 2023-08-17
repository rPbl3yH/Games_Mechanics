using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestTimeRewardDebug : MonoBehaviour
    {
        [Header("Debug")]
        [ShowInInspector] 
        [Inject] private MoneyStorage _moneyStorage;
    }
}