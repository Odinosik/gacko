using GACKO.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared
{
    public interface IDbContextOptionsFactory
    {
        DbContextOptions<GackoDbContext> Get();
    }
}
