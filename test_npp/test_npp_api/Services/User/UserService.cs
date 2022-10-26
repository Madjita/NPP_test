﻿using System;
using test_npp_api.Services.Repository;
using test_npp_api.Services.Tool;

namespace test_npp_api.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<EF_entities.Tool> _toolRepository;
        private readonly IRepository<EF_entities.User> _userRepository;

        public UserService(
         IRepository<test_npp_api.EF_entities.Tool> toolRepository,
         IRepository<test_npp_api.EF_entities.User> userRepository
        )
        {
            _toolRepository = toolRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<EF_entities.User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        Task<EF_entities.User> IUserServiceRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

