﻿using Foodies.Common;
using Foodies.Exceptions;
using Foodies.Interfaces.Repositories;
using Foodies.Interfaces.Services;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Foodies.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CustomerService(ICustomerRepository customerRepository, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Customer> CreateCustomer(RegistrationViewModel viewModel)
        {
            var existingCustomer = await _userManager.FindByEmailAsync(viewModel.Email);
            if(existingCustomer != null)
            {
                throw new UserAlreadyExistsException(viewModel.Email);
            }
            IdentityUser user = new IdentityUser();
            user.UserName = viewModel.Email;
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;

            IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer)).GetAwaiter().GetResult();
                await _userManager.AddToRoleAsync(user, "Customer");
                Customer customer = new Customer
                {
                    Id = user.Id,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    img= viewModel.img,

                    Address = new Address
                    {
                        Id = Guid.NewGuid().ToString(),
                        City = viewModel.City,
                        Street = viewModel.Street,
                        Building = viewModel.Building,
                        Location = viewModel.Location,
                    },
                    IdentityUser = user,
                };
                await _customerRepository.Create(customer);
                return customer;
            }
            return null;
        }
    }
}
