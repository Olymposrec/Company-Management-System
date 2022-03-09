using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class FileUploadManager : IFileUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileUploadManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(FileUpload entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.FileUploads.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(FileUpload entity)
        {
            _unitOfWork.FileUploads.Delete(entity);
            _unitOfWork.Save();
        }

        public List<FileUpload> GetAll()
        {
            return _unitOfWork.FileUploads.GetAll();
        }

        public FileUpload GetById(int id)
        {
            return _unitOfWork.FileUploads.GetById(id);
        }

        public bool Update(FileUpload entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.FileUploads.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(FileUpload entity)
        {
            var isValid = true;
            if (entity.FileExtension.Contains(".exe") || entity.FileExtension.Contains(".dll"))
            {
                ErrorMessage += "You cannot upload dll and exe files. ";
                return false;
            }           
            return isValid;
        }
    }
}
