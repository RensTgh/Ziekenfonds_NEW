using Microsoft.AspNetCore.Mvc;
using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.DTOS.Monitor;

namespace ZiekenFonds.Web.Services
{
    public interface IMonitorService
    {
        Task<MonitorDTO?> GetMonitorAsync(int id);
        Task<MonitorGegevensDTO[]> GetAllMonitorsWithDetailsAsync();
        Task CreateMonitorAsync(CreateMonitorDTO dto);
    }
}