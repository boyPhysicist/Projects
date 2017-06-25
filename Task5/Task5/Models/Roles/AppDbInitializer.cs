using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Task5.Models.Roles
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru" };
            string password = "Admin_1";
            var result = userManager.Create(admin, password);
            var user = new ApplicationUser { Email = "user@mail.ru", UserName = "user@mail.ru" };
            string password1 = "User_1";
            var result1 = userManager.Create(user, password1);
            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                //userManager.AddToRole(admin.Id, role2.Name);
            }
            if (result1.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}