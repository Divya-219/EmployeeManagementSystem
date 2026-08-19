using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery:IRequest<EmployeeDto?>
    {
        public int Id { get; set; }
        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
