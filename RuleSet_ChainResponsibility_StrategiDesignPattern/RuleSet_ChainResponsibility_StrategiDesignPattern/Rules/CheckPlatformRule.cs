using RuleSet_ChainResponsibility_StrategiDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern.Rules
{
    class CheckPlatformRule : Rule, IRule
    {
        //Check Platform And Token and IMEI No
        public CheckPlatformRule()
        {
            NextRule =new CheckTokenRule();

        }

        public EnumPlatform Platform { get;  set; }

        public bool Run(RequestModel model)
        {

            if(model.IMEI == String.Empty || model.IMEI == null)
            {
                NextRule.Platform = EnumPlatform.Web;
                return model.Token != String.Empty &&  model.Token != null;
            }
            else
            {
                NextRule.Platform = EnumPlatform.GSM;
                return (model.Token != String.Empty && model.Token != null) || (model.RefreshToken != String.Empty && model.RefreshToken != null);
            }

        }
    }
}
