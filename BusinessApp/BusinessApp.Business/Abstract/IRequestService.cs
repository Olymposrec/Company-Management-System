using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Abstract
{
    public interface IRequestService:IValidator<Request>
    {
        Request GetById(int id);
        Request GetByUserId(string userId);
        List<Request> GetAll();
        bool Create(Request entity);
        Task CreateAsync(Request entity);
        bool Update(Request entity);
        void Delete(Request entity);
        List<Request> GetSearchResult(string searchString,int? companyServiceserviceId,Request.EnumRequestStatus requestStatus,string serviceName);
        List<Request> GetSearchResult(string q);
    }
}
