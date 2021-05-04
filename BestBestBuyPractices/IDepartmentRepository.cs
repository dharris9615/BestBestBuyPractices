using System;
using System.Collections.Generic;

namespace BestBestBuyPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
