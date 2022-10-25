using chat_server.Context;
using chat_server.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    class GetUserQuery : IRequest<List<User>>
    {

        private sealed class QueryHandler : IRequestHandler<GetUserQuery, List<User>>
        {
            private readonly ChatContext _chatContext;
            public QueryHandler(ChatContext chatContext)
            {
                _chatContext = chatContext;
            }
            public async Task<List<User>> Handle(GetUserQuery request, CancellationToken cancelationToken)
            {
                var users = _chatContext.Users.ToList();

                return users;
            }
        }
    }
}
