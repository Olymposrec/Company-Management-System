using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Abstract
{
    public interface IRequestRepository:IRepository<Request>
    {
        List<Request> GetSearchResult(string q);
        Request GetByUserId(string userId);
        List<Request> GetSearchResult(string searchString, int? companyServiceserviceId, Request.EnumRequestStatus requestStatus,string serviceName);
    }
}
