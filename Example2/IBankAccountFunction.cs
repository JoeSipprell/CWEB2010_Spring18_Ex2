using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    public interface IBankAccountFunction
    {
        void Deposit(double depo);
        void WithDraw(double withdraw);

        double Balance();
    }
}
