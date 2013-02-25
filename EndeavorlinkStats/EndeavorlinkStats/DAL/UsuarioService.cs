using EndeavorlinkStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndeavorlinkStats.DAL
{
    public class UsuarioService : IUsuarioService
    {
        private StatsContextContainer context = new StatsContextContainer();
        public List<tbl_user> getAll()
        {
            return (from users in context.tbl_user select users).ToList<tbl_user>();
        }

        public tbl_user getUser(string username)
        {
            var userList = (from users in context.tbl_user where users.name == username select users).ToList();
            Console.WriteLine(userList);
            if (userList.Count() == 0)
            {
                throw new ArgumentException("Incorrect Username/Password");
            }
            var user = userList.First();
            return user;
        }

        public int getID(string username)
        {
            int ret = (int)(from users in context.tbl_user where users.name == username select users.id_user).First();
            return ret;
        }
        public Dictionary<String,List<String>> getOperatorModel(int id_user)
        {
            Dictionary<String, List<String>> operatorsForCountry = new Dictionary<string, List<string>>();
            var query = context.sp_get_user_operator(id_user).ToList();
            List<String> operatorsPeru = new List<string>();
            List<String> operatorsColombia = new List<string>();
            List<String> operatorsMexico = new List<string>();
            List<String> operatorsBrasil = new List<string>();
            List<String> operatorsDR = new List<string>();
            foreach (var record in query)
            {
                switch ((int)record.id_pais)
                {
                    case 1:
                        {
                            operatorsPeru.Add(record.name);
                            break;
                        }
                    case 2:
                        {
                            operatorsColombia.Add(record.name);
                            break;
                        }
                    case 3:
                        {
                            operatorsDR.Add(record.name);
                            break;
                        }
                    case 4:
                        {
                            operatorsMexico.Add(record.name);
                            break;
                        }
                }

            }

            if(operatorsPeru.Count != 0)
                operatorsForCountry.Add("PERU", operatorsPeru);
            if (operatorsColombia.Count != 0)
                operatorsForCountry.Add("COLOMBIA", operatorsColombia);
            if (operatorsDR.Count != 0)
                operatorsForCountry.Add("DOMINICAN REPUBLIC", operatorsDR);
            if (operatorsMexico.Count != 0)
                operatorsForCountry.Add("MEXICO", operatorsMexico);

            return operatorsForCountry;
        }

    }
}