using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface IRequestResponseService: IValidator<RequestResponse>
    {
        RequestResponse GetById(int id);
        List<RequestResponse> GetAll();
        bool Create(RequestResponse entity);
        bool Update(RequestResponse entity);
        void Delete(RequestResponse entity);
    }
}
