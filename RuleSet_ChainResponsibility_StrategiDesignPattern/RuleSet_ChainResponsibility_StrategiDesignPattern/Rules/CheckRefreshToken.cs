using RuleSet_ChainResponsibility_StrategiDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern.Rules
{
    class CheckRefreshToken : Rule, IRule
    {
        public CheckRefreshToken()
        {
            NextRule = null;
        }
        //If expaire date less than  45min, we will refresh the expaire date.
        public EnumPlatform Platform { get; set ; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case EnumPlatform.GSM:
                {
                    if((FakeData.TokenExpireDate - model.TokenExpireDate).TotalMinutes < 45)
                    {
                            if(model.RefreshToken == FakeData.RefreshToken)
                            {
                                FakeData.Token = "57046292566V2";
                                FakeData.RefreshToken = "asdasdasd";
                                FakeData.TokenExpireDate = new DateTime(2022, 9, 30, 5, 50, 5);
                            }
                    }
                        break;
                }
                case EnumPlatform.Web:
                    {
                        if((FakeData.TokenExpireDate - model.TokenExpireDate).TotalMinutes < 45)
                        {
                            if (model.RefreshToken == FakeData.RefreshToken)
                            {
                                FakeData.Token = "57046292566V2";
                                FakeData.RefreshToken = "asdasdasd";
                                FakeData.TokenExpireDate = new DateTime(2022, 9, 30, 5, 50, 5);
                            }
                        }
                        break;
                    }

            }
            return true; //"200 OK"
        }
    }
}
