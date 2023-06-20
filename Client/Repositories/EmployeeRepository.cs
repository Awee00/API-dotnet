using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Client.Repositories
{
    public class EmployeeRepository
    {
        private readonly string request;
        private readonly HttpContextAccessor contextAccessor;
        private readonly HttpClient httpClient;

        public EmployeeRepository(string request = "Employee/")
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7238/api/")
            };
        }

        public async Task<ResponseDataVM<List<Employee>>> Get()
        {
            ResponseDataVM<List<Employee>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Employee>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<string>> Post(Employee employee)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result) //localhost/api/employee {method:post} -> content
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Employee>> Get(int id)
        {
            ResponseDataVM<Employee> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Employee>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<string>> Put(int id, Employee employee)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PutAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<string>> Delete(int id)
        {
            ResponseDataVM<string> entityVM = null;
            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }
    }
}
