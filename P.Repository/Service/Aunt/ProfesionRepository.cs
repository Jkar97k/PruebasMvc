using P.Interfaces;
using P.Model.Data;
using P.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Repository.Service.Aunt
{
    public class ProfesionRepository : GenericRepository<Profesion>, IProfesionRepository
    {
        public ProfesionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
