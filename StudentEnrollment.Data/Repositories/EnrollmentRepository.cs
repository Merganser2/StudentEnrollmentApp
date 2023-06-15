﻿using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data.Repositories
{
    // For extensibility
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository    
    {        
        public EnrollmentRepository(StudentEnrollmentDbContext db) : base(db)
        {
        }
    }
}
