using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay.Installer
{
    [CreateAssetMenu(menuName = "Create ConfigsInstaller", fileName = "ConfigsInstaller", order = 0)]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private EnemySpawnConfig _config; 
        public override void InstallBindings()
        {
            Container.Bind<EnemySpawnConfig>().FromScriptableObject(_config).AsSingle();
        }
    }
}