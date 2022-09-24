using RuleSet_ChainResponsibility_StrategiDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern
{
    public interface IRule
    {
        bool Run(RequestModel model);
        EnumPlatform Platform { get; set; }
        IRule NextRule { get; set; }

    }
}
