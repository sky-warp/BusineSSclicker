using _Project.Scripts.BusinessContainer.View;
using _Project.Scripts.BusinessTotalAmount.View;
using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private BaseBusinessWindowView _businessWindowView;
        [SerializeField] private GlobalBusinessesConfig _config;

        [SerializeField] private BaseBusinessContainerView _viewPrefab;
        [SerializeField] private Transform _bussinessesParent;

        private void Start()
        {
            var startup = new StartupEcs();
            startup.Init(_businessWindowView, _config, _viewPrefab, _bussinessesParent);
            startup.Startup();
        }
    }
}