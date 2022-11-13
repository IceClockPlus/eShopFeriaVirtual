using eShopFeriaVirtual.Contracts.Authentication;
using eShopFeriaVirtual.Infrastructure.Database;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Users.Authentication
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, AuthenticationResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AuthenticateUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<AuthenticationResponse> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
