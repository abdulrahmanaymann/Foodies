﻿using Foodies.Common;
using Foodies.Data;
using Foodies.Exceptions;
using Foodies.Interfaces.Repositories;

namespace Foodies.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly FoodiesDbContext _context;
        public AddressRepository(FoodiesDbContext context)
        {
            _context = context;
        }
        public async Task<Address> Create(Address entity)
        {
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Address> Delete(string id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException($"Address with ID {id} not found");
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return addresses;
        }

        public async Task<Address> GetById(string id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException($"Address with ID {id} not found");
            return address;
        }

        public async Task<Address> Update(Address entity)
        {
            _context.Addresses.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
