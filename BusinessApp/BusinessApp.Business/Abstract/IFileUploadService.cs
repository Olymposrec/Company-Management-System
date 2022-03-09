using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface IFileUploadService:IValidator<FileUpload>
    {
        FileUpload GetById(int id);
        List<FileUpload> GetAll();
        bool Create(FileUpload entity);
        bool Update(FileUpload entity);
        void Delete(FileUpload entity);
    }
}
