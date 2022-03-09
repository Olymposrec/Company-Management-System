using BusinessApp.Entity;
using BusinessApp.WebUI.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BusinessApp.Entity.Request;

namespace BusinessApp.WebUI.Models.RequestsModels
{
    public class RequestsModel
    {
        public EnumRequestStatus EnumRequestStatus { get; set; }

        [Required(ErrorMessage = "Request Title is Required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Request Title Length must be between 3-50.")]
        [DataType(DataType.Text, ErrorMessage = "Request Title  must be text.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Request Title is Required.")]
        [StringLength(350, MinimumLength = 5, ErrorMessage = "Request Description Length must be between 5-350.")]
        [DataType(DataType.Text, ErrorMessage = "Request Description  must be text.")]
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public string selectedService { get; set; }

        public Request Request { get; set; }
        public List<Request> Requests { get; set; }
        public RequestResponse? RequestResponse { get; set; }
        public List<RequestResponse>? RequestResponses { get; set; }
        public User? User { get; set; }
        public List<User> Users { get; set; }
        public List<CompaniesService> CompaniesServices { get; set; }
        public List<RequestDepartment> RequestDepartments { get; set; }
        public List<EmployeeDepartment> EmployeeDepartments { get; set; }
        public List<Department> Departments { get; set; }
        public List<Service> Services { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<FileUpload> FilesDownload { get; set; }
        public List<EmployeeRequests> EmployeeRequests { get; set; }
    }
    public class RequestsListModel
    {
        public string Url { get; set; }
        [Display(Prompt = "Query String", Name = "Query String")]
        public string queryString { get; set; }
        [Display(Prompt = "Service Name", Name = "Service Name")]
        public string serviceName { get; set; }
        [Display(Prompt = "Request Status", Name = "Request Status")]
        public Request.EnumRequestStatus? requestStatus { get; set; }
        public string EmployeeId { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }
        public List<Request> Requests { get; set; }
        public List<Service> Services { get; set; }
        public List<CompaniesService> CompaniesServices { get; set; }
        public List<EmployeeRequests> EmployeeRequests { get; set; }
    }
    
}
