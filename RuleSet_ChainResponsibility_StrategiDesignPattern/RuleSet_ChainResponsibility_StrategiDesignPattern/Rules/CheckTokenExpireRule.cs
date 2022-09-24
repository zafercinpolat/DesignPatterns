using RuleSet_ChainResponsibility_StrategiDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern.Rules
{
    class CheckTokenExpireRule : Rule, IRule
    {
        public CheckTokenExpireRule()
        {
            NextRule = new CheckRefreshToken();
        }
        public EnumPlatform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case EnumPlatform.GSM:
                    {
                        NextRule.Platform = EnumPlatform.GSM;
                        if (model.TokenExpireDate < FakeData.TokenExpireDate.AddHours(2))
                        {
                            return true;
                        }
                        return false;
                    }
                case EnumPlatform.Web:
                    {
                        NextRule.Platform = EnumPlatform.Web;
                        if (model.TokenExpireDate < FakeData.TokenExpireDate)
                        {
                            return true;
                        }
                        return false;
                    }
                default:
                    {
                        return false;

                    }
            }

        }
    }
}
