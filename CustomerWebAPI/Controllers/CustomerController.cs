using System;
using System.Collections.Generic;
using System.Data;
using CustomerWebAPI.Models;
using CustomerWebAPI.Util;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public List<CustomerModel> GetCustomers()
        {
            return new CustomerModel().GetCustomers();
        }

        [HttpGet("{id}")]
        public CustomerModel GetCustomer(int id)
        {
            return new CustomerModel().GetCustomer(id);
        }

        [HttpPost]
        [Route("create")]
        public ReturnAllServices CreateCustomer([FromBody] CustomerModel customer)
        {
            ReturnAllServices ret = new ReturnAllServices();

            try
            {
                customer.CreateCustomer();
                ret.Result = true;
                ret.ErrorMessage = string.Empty;

            }
            catch (Exception e)
            {
                ret.Result = false;
                ret.ErrorMessage = "Error while trying to create a customer: " + e.Message;
            }

            return ret;
        }

        [HttpPut]
        [Route("update/{id}")]
        public ReturnAllServices UpdateCustomer(int id, [FromBody] CustomerModel customer)
        {
            ReturnAllServices ret = new ReturnAllServices();

            try
            {
                customer.UpdateCustomer(id);
                ret.Result = true;
                ret.ErrorMessage = string.Empty;

            }
            catch (Exception e)
            {
                ret.Result = false;
                ret.ErrorMessage = "Error while trying to update a customer: " + e.Message;
            }

            return ret;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ReturnAllServices DeleteCustomer(int id)
        {
            ReturnAllServices ret = new ReturnAllServices();

            try
            {
                new CustomerModel().DeleteCustomer(id);
                ret.Result = true;
                ret.ErrorMessage = string.Empty;

            }
            catch (Exception e)
            {
                ret.Result = false;
                ret.ErrorMessage = "Error while trying to delete a customer: " + e.Message;
            }

            return ret;
        }
    }
}
