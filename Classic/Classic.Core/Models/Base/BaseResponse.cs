using System;
using System.Collections.Generic;
using System.Text;

namespace Classic.Core.Models.Base
{
    public class BaseResponse
    {
        public string Mensage { get; set; }
        public bool IsCorrect { get; set; }
        public BaseResponse()
        {
            Mensage = "No se ha podido realizar la operación";
            IsCorrect = false;
        }

    }
}
