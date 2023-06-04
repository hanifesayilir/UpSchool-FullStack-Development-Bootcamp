
using Application.Common.Interfaces;
using Blazored.Toast.Services;
using Microsoft.JSInterop;
using Shipwreck.BlazorJqueryToast;

namespace FinalProject.Wasm.Services
{
    public class ToasterService : IToasterService
    {
        private readonly IJSRuntime _jsRuntime;

        public ToasterService(IJSRuntime jSRuntime)
        {
            _jsRuntime= jSRuntime;
        }

        public void ShowError(string message)
        {
            _jsRuntime.ShowToastAsync(new ToastOptions
            {
                Text = message,
                Position = ToastPosition.TopCenter,
                Heading = "Error!"
            });
        }

        public void ShowSuccess(string message)
        {
            _jsRuntime.ShowToastAsync(new ToastOptions
            {
                Text = message,
                Position = ToastPosition.TopCenter,
                Heading = "UpSchool"
            });
        }
    }
}
