using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndeavorlinkStats.DAL
{
    public class UsuarioService : IUsuarioService
    {
        private smartg context = new smartg();
        public List<tbl_user> getAll()
        {
            return (from users in context.tbl_user select users).ToList<tbl_user>();
        }

        public tbl_user getUser(string username)
        {
            var userList = (from users in context.tbl_user where users.name == username select users);
            if (userList.Count() == 0)
            {
                throw new ArgumentException("Usuario/Contraseña incorrectos");
            }
            var user = userList.First();
            return user;
        }

        public int getID(string username)
        {
            return int.Parse((from users in context.tbl_user where users.name == username select users.id_user).ToString());
        }

    }
}