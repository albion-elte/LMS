namespace LMS.Application.Interfaces
{
    public interface IInventoryService
    {
        void NotifySaleOccurred(int productId, int quantity);
    }
}
