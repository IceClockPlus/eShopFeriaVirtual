using eShopFeriaVirtual.Application.Services;
using eShopFeriaVirtual.Application.Wrapper;
using eShopFeriaVirtual.Domain.DTO.Users;
using eShopFeriaVirtual.Domain.Entities.Users;
using eShopFeriaVirtual.Infrastructure.Database;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Users
{
    public class RegisterUserCommand : IRequest<Response<RegisterUserResponseDto>>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<RegisterUserResponseDto>>
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IApplicationDbContext _context;
        public RegisterUserCommandHandler(IApplicationDbContext context, IPasswordHasherService passwordHasherService)
        {
            _context = context;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<Response<RegisterUserResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            bool isEmailExists = await _context.UserCollection.Find(u => u.Email == request.Email).AnyAsync();
            if (isEmailExists)
                return new Response<RegisterUserResponseDto>("Correo ya registrado");

            string passwordHash = _passwordHasherService.HashPassword(request.Password, out var bytesSalt);
            User user = new()
            {
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
                Password = passwordHash,
                Salt = Convert.ToBase64String(bytesSalt)
            };
            await _context.UserCollection.InsertOneAsync(user);
            RegisterUserResponseDto dto = new()
            {
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName
            };
            return new(dto);
        }
    }
}
