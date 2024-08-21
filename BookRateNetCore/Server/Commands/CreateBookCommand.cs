using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRateNetCore.Shared.Dtos;
using BookRateNetCore.Shared.Models;
using MediatR;

namespace BookRateNetCore.Shared.Commands
{
    public class CreateBookCommand : Book, IRequest
    {

    }
}
