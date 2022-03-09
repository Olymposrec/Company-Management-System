using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        ICompaniesServiceRepository CompaniesService { get;}
        ICompanyRepository Companies { get; }
        IDepartmentRepository Departments { get; }
        IFileUploadRepository FileUploads { get; }
        IRequestRepository Requests { get; }
        IRequestResponseRepository RequestResponses { get; }
        IRequestDepartmentRepository RequestDepartments { get; }
        IUsersApplicationRepository UsersApplications { get; }
        IServiceRepository Services { get; }
        IServiceUserRepository ServiceUsers { get; }
        IEmployeeDepartmentRepository EmployeeDepartments { get; }
        IEmployeeRequestsRepository EmployeeRequests { get; }
        ILogsRepository Logs { get;}
        

        void Save();
        Task<int> SaveAsync();

    }
}
