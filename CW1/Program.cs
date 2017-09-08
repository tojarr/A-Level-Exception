using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1
{
    enum UserType
    {
        Admin = 1,
        User = 2
    }
    class UserValidation
    {
        public string adminLog;
        public string adminPass;
        public string userLog;
        public string userPass;

        public UserValidation()
        {
            adminLog = "admin";
            adminPass = "123";
            userLog = "user";
            userPass = "111";
        }

        public int ValidationUser()
        {
            string log, pass;
            int a = 0, b = 0;
                Console.Write("Enter login:");
                log = Console.ReadLine();
                Console.Write("Enter passwor:");
                pass = Console.ReadLine();
            try
            {
                a = ValidLog(log);
                if (a > 0)
                {
                     b = ValidPass(pass, a);
                }
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return b;
        }
        public int ValidLog(string log)
        {
            if (log == adminLog)
            {
                return 1;
            }
            else if(log == userLog)
            {
                return 2;
            }
            else
            {
                throw new AggregateException("Incorrect login");
            }
        }
        public int ValidPass(string pass, int b)
        {
            if (b == 1 & pass == adminPass)
            {
                return 1;
            }
            else if (b == 2 & pass == userPass)
            {
                return 2;
            }
            else
            {
                throw new AggregateException("Incorrect password");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserValidation uw = new UserValidation();
            int ex = uw.ValidationUser();
            if (ex > 0)
            {
                UserType us = (UserType)ex;
                Console.WriteLine(us.ToString());
            }
        }
    }
}
