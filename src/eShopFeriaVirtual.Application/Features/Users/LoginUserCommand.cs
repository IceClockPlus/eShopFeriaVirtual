using eShopFeriaVirtual.Application.Services;
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
    public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasherService _passwordHasherService;
        public LoginUserCommandHandler(IApplicationDbContext context, IPasswordHasherService passwordHasherService)
        {
            _context = context;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.UserCollection.Find(u => u.Email == request.Email).FirstOrDefaultAsync();
            if (user == null) return null;
            var saltByte = Convert.FromBase64String(user.Salt);
            if(_passwordHasherService.VerifyPassword(request.Password, user.Password, saltByte))
            {
                return new LoginUserDto
                {
                    Email = user.Email,
                    Name = user.Name,
                    Lastname = user.LastName,
                    UserId = user.UserId,
                };
            }
            return null;
        }
    }
}
