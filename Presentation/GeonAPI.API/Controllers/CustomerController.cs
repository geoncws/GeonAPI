using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeonAPI.Application.Repositories;
using GeonAPI.Application.ViewModels.Customers;
using GeonAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeonAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        public CustomerController(ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_customerReadRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _customerReadRepository.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_CreateCustomer model)
        {
            await _customerWriteRepository.AddAsync(new()
            {
                NameSurname = model.NameSurname,
                Phone = model.Phone,
                Address = model.Address
            });
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_UpdateCustomer model)
        {
            Customer customer = await _customerReadRepository.GetByIdAsync(model.Id);
            customer.NameSurname = model.NameSurname;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        { 
            await _customerWriteRepository.RemoveAsync(id);
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
