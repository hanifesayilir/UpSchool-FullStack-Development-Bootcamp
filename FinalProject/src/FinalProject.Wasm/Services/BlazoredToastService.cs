
using Application.Common.Interfaces;
using Blazored.Toast.Configuration;
using Blazored.Toast.Services;

namespace FinalProject.Wasm.Services
{
    public class BlazoredToastService : IToasterService
    {
        private readonly IToastService _toastService;

        public BlazoredToastService(IToastService _toastService)
        {
            _toastService = _toastService;
        }

        public void ShowSuccess(string message)
        {
            _toastService.ShowSuccess(message);
        }

        public void ShowError(string message)
        {
            _toastService.ShowError(message);
        }
    }
}
