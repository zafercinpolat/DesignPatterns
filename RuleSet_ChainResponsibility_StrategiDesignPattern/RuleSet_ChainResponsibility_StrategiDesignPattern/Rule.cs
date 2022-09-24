using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet_ChainResponsibility_StrategiDesignPattern
{
    public class Rule
    {
        public IRule NextRule { get; set; }
    }
}
