using Prueba.Domain.DTOs;
using Prueba.Domain.Entities;
using Prueba.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task Create(RegisterRequest userTemp);
        Task<User> GetByCorreo(string correo);
        Task<User> GetById(int id);
        Task Update(User user);
        Task<int> Delete(int id);
    }
}
