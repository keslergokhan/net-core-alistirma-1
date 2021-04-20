using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOGRENME.Core.Abstract
{
    public interface IReturnException<T>
    {
        public bool Status { get; set; }
        public Exception Exception { get; set; }
        public String Message { get; set; }
        public T Data { get; set; }

        void SetReturnException(bool Status,String Message,T Data, Exception Exception = null);
    }
}
