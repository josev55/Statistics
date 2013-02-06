using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndeavorlinkStats.DAL
{
    public interface IUsuarioService
    {
        List<tbl_user> getAll();
        tbl_user getUser(String username);
        int getID(String username);
    }
}
