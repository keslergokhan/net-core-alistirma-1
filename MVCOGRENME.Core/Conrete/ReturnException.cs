using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Core.Conrete
{
    public class ReturnException <T> : IReturnException<T>
    {
        public bool Status { get; set; }
        public Exception Exception { get; set; }
        public String Message { get; set; }
        public T Data { get; set; }

        public void SetReturnException(bool Status, string Message, T Data, Exception Exception = null)
        {
            this.Status = Status;
            this.Exception = Exception;
            this.Message = Message;
            this.Data = Data;
        }


    }
}
