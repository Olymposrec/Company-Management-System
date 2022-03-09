using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreRequestRepository : EfCoreGenericRepository<Request>, IRequestRepository
    {
        public EfCoreRequestRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }

        public Request GetByUserId(string userId)
        {
            return BusinessAppContext.Request.Where(c => c.UserId == userId).FirstOrDefault();
        }

        public List<Request> GetSearchResult(string q)
        {
            var serviceRequest = BusinessAppContext.Request
                  .Where(p => p.Description.ToLower().Contains(q.ToLower()) || p.Description.ToLower().Contains(q.ToLower())
                  || p.Title.ToLower().Contains(q.ToLower()))
                  .AsQueryable();
            return serviceRequest.ToList();
        }

        public List<Request> GetSearchResult(string searchString, int? companyServiceserviceId, Request.EnumRequestStatus requestStatus, string serviceName)
        {
            var request = BusinessAppContext.Request.ToList().AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
                request = BusinessAppContext.Request.Where(c => c.Description.ToLower().Contains(searchString.ToLower())
                || c.Title.ToLower().Contains(searchString.ToLower()));  request = BusinessAppContext.Request.Where(c => c.CompaniesServiceId == companyServiceserviceId).AsQueryable();

            if (requestStatus!=0)
                request = BusinessAppContext.Request.Where(c => c.RequestStatus==requestStatus);

            return request.ToList();
            
        }
    }
}
