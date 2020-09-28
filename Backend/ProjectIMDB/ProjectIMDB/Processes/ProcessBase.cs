using ProjectIMDB.Repository;

namespace ProjectIMDB.Processes
{
    public class ProcessBase
    {
        protected InterfaceUnitOfWork UnitOfWork { get; }

        protected ProcessBase(InterfaceUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}