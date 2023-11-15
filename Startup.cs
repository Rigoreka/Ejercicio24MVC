using Ejercicio24MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicio24MVC.Startup))]
namespace Ejercicio24MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesUsuarios();
        }
        void CrearRolesUsuarios()
        {
            //manejadores de roles y manejador de usuarios
            ApplicationDbContext context = new ApplicationDbContext();
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)); //agregar nuevos roles
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //definimos cada uno de los roles del sistema y establecemos un usuario por defecto
            //para cada rol

            if (!ManejadorRol.RoleExists("Admin"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                var rol = new IdentityRole();
                rol.Name = "Admin"; ManejadorRol.Create(rol);
                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                //los parametros del objeto de el usuario
                user.UserName = "Amo@sistemas.com";
                user.Email = "Amo@sistemas.com";
                string PWD = "12345678";

                //Se crea el usuario
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //asignamos rol al usuario
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Admin");
                }

            }

            //Rol Miembros


            if (!ManejadorRol.RoleExists("Miembros"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                var rol = new IdentityRole();
                rol.Name = "Miembros"; ManejadorRol.Create(rol);
                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                //los parametros del objeto deel usuario
                user.UserName = "juanprez@Yahoo.es";
                user.Email = "juanprez@Yahoo.es";
                string PWD = "12345678";

                //Se crea el usuario
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //asignamos rol al usuario
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Miembros");
                }

            }
        }
    }
}
