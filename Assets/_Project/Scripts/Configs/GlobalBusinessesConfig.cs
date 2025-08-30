using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "GlobalBusinessConfig", menuName = "Configs/GlobalBusinessesConfig")]
    public class GlobalBusinessesConfig : ScriptableObject
    {
        [field: SerializeField] public BusinessItemConfig[] Configs { get; private set; }
    }
}