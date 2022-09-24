using RuleSet_ChainResponsibility_StrategiDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern.Rules
{
    public class CheckTokenRule : Rule, IRule
    {

        public CheckTokenRule()
        {
            NextRule = new CheckTokenExpireRule();
        }
        public EnumPlatform Platform { get ; set ; }

        public bool Run(RequestModel model)
        {
            switch(Platform)
            {
                case EnumPlatform.GSM:
                    {
                        NextRule.Platform = EnumPlatform.GSM;
                        return (model.UserID == FakeData.UserID) && (model.Token == FakeData.Token || model.RefreshToken == FakeData.RefreshToken) ;
                    }
                case EnumPlatform.Web:
                    {
                        //not check RefreshToken for Web Platform
                        NextRule.Platform = EnumPlatform.Web;
                        return model.UserID == FakeData.UserID && model.Token == FakeData.Token;
                    }
                default:
                    {
                        return false; //Unauthorized 401
                    }
            }

          
        }
    }
}
