using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game
{
    public class ChestTimeRewardDebug : MonoBehaviour
    {
        [Header("Debug")]
        [ShowInInspector] 
        [Inject] private MoneyStorage _moneyStorage;
    }
}