using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLang
{
    public class FuncExpression : Expression
    {
      private IEnumerable<Expression> expressions;
      public FuncExpression(IEnumerable<Expression> expressions)
      {
          this.expressions = expressions;
      }
      public override void Eval()
      {
          Console.WriteLine("Evaluating function");
      }
    }
}
