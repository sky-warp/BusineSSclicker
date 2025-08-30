using UnityEngine;

namespace _Project.Scripts.BusinessContainer.View
{
    public class BusinessContainerFactory : BaseBusinessContainerFactory
    {
        public BusinessContainerFactory(BaseBusinessContainerView prefab, Transform parent) : base(prefab, parent)
        {
        }

        public override BaseBusinessContainerView Create()
        {
            return GameObject.Instantiate(Prefab, Parent);
        }
    }
}