using CustomerWebAPI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CustomerWebAPI.Models
{
    public class CustomerModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string RegisterDate { get; set; }
        [Required]
        public string CpfCnpj { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public string Complement { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Fu { get; set; }

        public void CreateCustomer()
        {
            DAL objDAL = new DAL();

            string sql = "INSERT INTO customer(CUSTOMER_NAME, REGISTER_DATE, CPF_CNPJ, BIRTH_DATE, USER_TYPE, PHONE, EMAIL, STREET, HOUSE_NUMBER, NEIGHBORHOOD, COMPLEMENT, CITY, POSTAL_CODE, FU)" +
                            $"VALUES('{CustomerName}', '{DateTime.Parse(RegisterDate).ToString("yyyy/MM/dd")}', '{CpfCnpj}', '{DateTime.Parse(BirthDate).ToString("yyyy/MM/dd")}', '{UserType}', '{Phone}', '{Email}', '{Street}', '{HouseNumber}', '{Neighborhood}', '{Complement}', '{City}', '{PostalCode}', '{Fu}')";


            objDAL.RunSQLCommand(sql);
        }

        public List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            DAL objDAL = new DAL();
            CustomerModel item;

            string sql = "SELECT * FROM customer ORDER BY CUSTOMER_NAME";
            DataTable data = objDAL.GetDataTable(sql);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                item = new CustomerModel()
                {
                    Id = Int32.Parse(data.Rows[i]["ID"].ToString()),
                    CustomerName = data.Rows[i]["CUSTOMER_NAME"].ToString(),
                    RegisterDate = data.Rows[i]["REGISTER_DATE"].ToString(),
                    CpfCnpj = data.Rows[i]["CPF_CNPJ"].ToString(),
                    BirthDate = data.Rows[i]["BIRTH_DATE"].ToString(),
                    UserType = data.Rows[i]["USER_TYPE"].ToString(),
                    Phone = data.Rows[i]["PHONE"].ToString(),
                    Email = data.Rows[i]["EMAIL"].ToString(),
                    Street = data.Rows[i]["STREET"].ToString(),
                    HouseNumber = data.Rows[i]["HOUSE_NUMBER"].ToString(),
                    Neighborhood = data.Rows[i]["NEIGHBORHOOD"].ToString(),
                    Complement = data.Rows[i]["COMPLEMENT"].ToString(),
                    City = data.Rows[i]["CITY"].ToString(),
                    PostalCode = data.Rows[i]["POSTAL_CODE"].ToString(),
                    Fu = data.Rows[i]["FU"].ToString()
                };

                customers.Add(item);
            }

            return customers;
        }

        public CustomerModel GetCustomer(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM customer WHERE ID = {id}";
            DataTable data = objDAL.GetDataTable(sql);

            CustomerModel customer = new CustomerModel()
            {
                Id = Int32.Parse(data.Rows[0]["ID"].ToString()),
                CustomerName = data.Rows[0]["CUSTOMER_NAME"].ToString(),
                RegisterDate = data.Rows[0]["REGISTER_DATE"].ToString(),
                CpfCnpj = data.Rows[0]["CPF_CNPJ"].ToString(),
                BirthDate = data.Rows[0]["BIRTH_DATE"].ToString(),
                UserType = data.Rows[0]["USER_TYPE"].ToString(),
                Phone = data.Rows[0]["PHONE"].ToString(),
                Email = data.Rows[0]["EMAIL"].ToString(),
                Street = data.Rows[0]["STREET"].ToString(),
                HouseNumber = data.Rows[0]["HOUSE_NUMBER"].ToString(),
                Neighborhood = data.Rows[0]["NEIGHBORHOOD"].ToString(),
                Complement = data.Rows[0]["COMPLEMENT"].ToString(),
                City = data.Rows[0]["CITY"].ToString(),
                PostalCode = data.Rows[0]["POSTAL_CODE"].ToString(),
                Fu = data.Rows[0]["FU"].ToString()
            };

            return customer;
        }
    }
}
