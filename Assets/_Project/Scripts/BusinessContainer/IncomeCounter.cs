using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessContainer
{
    public class IncomeCounter : ISystem
    {
        public World World { get; set; }

        private Filter _businessItem;

        public void OnAwake()
        {
        }

        public void OnUpdate(float deltaTime)
        {
        }

        public void Dispose()
        {
        }
    }
}