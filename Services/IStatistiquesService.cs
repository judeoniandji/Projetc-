namespace GestionDesCommandes.Services
{
    public interface IStatistiquesService
    {
        Task<int> GetOrdersOfDayAsync();
        Task<int> GetDeliveriesOfDayAsync();
        Task<int> GetPaymentsOfDayAsync();
    }
}
