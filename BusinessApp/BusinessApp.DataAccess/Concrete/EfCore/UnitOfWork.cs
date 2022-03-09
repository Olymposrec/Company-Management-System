using BusinessApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusinessAppContext _context;
        public UnitOfWork(BusinessAppContext context)
        {
            _context = context;
        }
        private EfCoreCompanyRepository _companyRepository;
        private EfCoreCompaniesServiceRepository _companiesServiceRepository;
        private EfCoreDepartmentRepository _departmentRepository;
        private EfCoreFileUploadRepository _fileUploadRepository;
        private EfCoreRequestRepository _requestRepository;
        private EfCoreRequestResponseRepository _requestResponseRepository;
        private EfCoreUsersApplicationRepository _usersApplicationRepository;
        private EfCoreServiceRepository _serviceRepository;
        private EfCoreServiceUserRepository _serviceUserRepository;
        private EfCoreEmployeeDepartmentRepository _coreEmployeeDepartmentRepository;
        private EfCoreRequestDepartmentRepository _requestDepartmentRepository;
        private EfCoreEmployeeRequestsRepository _employeeRequestsRepository;
        private EfCoreLogRepository _logRepository;

        public ICompanyRepository Companies => 
            _companyRepository ??= new EfCoreCompanyRepository(_context);
        public ICompaniesServiceRepository CompaniesService => 
            _companiesServiceRepository ??= new EfCoreCompaniesServiceRepository(_context);
        public IDepartmentRepository Departments => 
            _departmentRepository ??= new EfCoreDepartmentRepository(_context);
        public IFileUploadRepository FileUploads =>
            _fileUploadRepository ??= new EfCoreFileUploadRepository(_context);
        public IRequestRepository Requests => 
            _requestRepository ??= new EfCoreRequestRepository(_context);
        public IRequestResponseRepository RequestResponses => 
            _requestResponseRepository ??= new EfCoreRequestResponseRepository(_context);
        public IUsersApplicationRepository UsersApplications => 
            _usersApplicationRepository ??= new EfCoreUsersApplicationRepository(_context);

        public IServiceRepository Services => 
            _serviceRepository ??= new EfCoreServiceRepository(_context);

        public IServiceUserRepository ServiceUsers => 
            _serviceUserRepository ??= new EfCoreServiceUserRepository(_context);

        public IEmployeeDepartmentRepository EmployeeDepartments =>
            _coreEmployeeDepartmentRepository ??= new EfCoreEmployeeDepartmentRepository(_context);

        public IRequestDepartmentRepository RequestDepartments =>
            _requestDepartmentRepository ??= new EfCoreRequestDepartmentRepository(_context);
        public IEmployeeRequestsRepository EmployeeRequests =>
      _employeeRequestsRepository ??= new EfCoreEmployeeRequestsRepository(_context);
        public ILogsRepository Logs =>
    _logRepository ??= new EfCoreLogRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
