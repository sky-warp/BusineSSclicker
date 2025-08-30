using UnityEngine;

namespace _Project.Scripts.BusinessContainer.View
{
    public abstract class BaseBusinessContainerFactory
    {
        protected BaseBusinessContainerView Prefab;
        protected Transform Parent;

        protected BaseBusinessContainerFactory(BaseBusinessContainerView prefab, Transform parent)
        {
            Prefab = prefab;
            Parent = parent;
        }

        public abstract BaseBusinessContainerView Create();
    }
}