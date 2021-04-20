using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Business.Abstract
{
    public interface IFileService
    {
        IReturnException<Object> FileUpload(IFormFile file,String filePath, bool directory = false, String fileName = null);
        IReturnException<Object> FileRemove(String filePath,bool directory = false);

    }
}
