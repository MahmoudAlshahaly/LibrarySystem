using LibrarySystem.BL.AutoMapper;
using LibrarySystem.BL.Manager.BookManagers;
using LibrarySystem.BL.Manager.BorrowBookManagers;
using LibrarySystem.BL.Manager.UserManagers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL
{
    public static class BLDependencyInjection
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(map => map.AddProfile(new DomainProfile()));
            services.AddScoped<IBookManager, BookManager>();
            services.AddScoped<IBorrowBookManager, BorrowBookManager>();
            services.AddScoped<IUserManager, UserManager>();
        }
    }
}
