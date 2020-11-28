using CustomerApplication.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerApplication.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string RegisterDate { get; set; }
        public string CpfCnpj { get; set; }
        public string BirthDate { get; set; }
        public string UserType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Fu { get; set; }

        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            string jsonRet = WebAPI.GetRequest(string.Empty, string.Empty);
            customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonRet);
            return customers;
        }

        public CustomerModel GetCustomer(int? id)
        {
            CustomerModel customer = new CustomerModel();
            string jsonRet = WebAPI.GetRequest(string.Empty, id.ToString());
            customer = JsonConvert.DeserializeObject<CustomerModel>(jsonRet);
            return customer;
        }

        public void CreateCustomer()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            string jsonRet = string.Empty;

            if(Id == 0)
            {
                jsonRet = WebAPI.PostRequest("create", jsonData);
            }
            else
            {
                jsonRet = WebAPI.PutRequest($"update/{Id}", jsonData);
            }
        }

        public void DeleteCustomer(int id)
        {
            string jsonRet = WebAPI.DeleteRequest("delete", id.ToString());
        }
    }
}
