using RuleSet_ChainResponsibility_StrategiDesignPattern.Models;
using RuleSet_ChainResponsibility_StrategiDesignPattern.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Chain of resposibity and strategy design pattern Example for login for authorizatin.*/

            RequestModel model = new RequestModel();
            //model.IMEI = "123111231564";
            model.Token = "576295266";
            model.RefreshToken = "5704629566xx";
            model.UserID = 0;
            model.TokenExpireDate = DateTime.Now.AddHours(6);

            IRule firstRule = new CheckPlatformRule();

            while (firstRule.NextRule != null)
            {
                if (firstRule.Run(model))
                {
                    firstRule = firstRule.NextRule;
                }
                else
                {
                    Console.WriteLine("Unauthorized 401!");
                    break;
                }
            }
            //Working Tail Rule Process
            if (firstRule.NextRule == null)
            {
                if (firstRule.Run(model))
                {
                    Console.WriteLine("Authorized 200 OK!");
                }
                else
                {
                    Console.WriteLine("Unauthorized 401!");
                }
            }

            Console.WriteLine("".PadRight(60, '*'));
            Console.WriteLine($"Token: {FakeData.Token}");
            Console.WriteLine($"RefreshToken: {FakeData.RefreshToken}");
            Console.WriteLine($"Token Expire Date: ${FakeData.TokenExpireDate}");
            Console.WriteLine("Hello world");
            Console.ReadLine();
        }
    }
}
