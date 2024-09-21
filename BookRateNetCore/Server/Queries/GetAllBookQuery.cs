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
        public Guid? Id { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        //public GetAllBookQuery(Guid? id)
        //{
        //    Id = id;
        //}

        public GetAllBookQuery(Guid? id, int? pageNumber, int? pageSize)
        {
            Id = id;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        //public GetAllBookQuery(int? pageNumber, int? pageSize)
        //{
        //    PageNumber = pageNumber;
        //    PageSize = pageSize;
        //}
    }
}
