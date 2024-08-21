using BookRateNetCore.Shared.Dtos;
using BookRateNetCore.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared.Queries
{
    public class GetAllBookQuery : IRequest<List<Book>>
    {
    }
}
