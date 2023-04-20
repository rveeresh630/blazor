using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BethanypieShopsHRM.Api.Repository;

using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Api.Models
{
    public class JobCategoryRepository: IJobCategoryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public JobCategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            return _appDbContext.JobCategories;
        }

        public JobCategory GetJobCategoryById(int jobCategoryId)
        {
            return _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
        }
    }
}
