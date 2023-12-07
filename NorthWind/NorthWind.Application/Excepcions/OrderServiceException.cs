

using System;

namespace NorthWind.Application.Excepcions
{
   public class OrderServiceException : Exception 
    {
        public OrderServiceException(string message): base(message)
        {
            // logica para envio de notificaciones o logger
        }

    }
}
