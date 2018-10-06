using System;

namespace HOK_App.Services
{
    public interface IErrorManagementService
    {
        void HandleError(string message);
        void HandleError(string message, Exception ex);
        void HandleError(Exception ex);
    }
}