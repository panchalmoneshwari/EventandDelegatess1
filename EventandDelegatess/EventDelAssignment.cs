using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventandDelegatess
{
    public delegate void Mydel();
    class Bank
    {
        int act_bal;
        public event Mydel Zero;
        public event Mydel Inefficient_bal;

        public Bank(int act_bal)
        {
            this.act_bal = act_bal;
        }
        public void Debit(int debit_amt)
        {
            if (act_bal == 0)
            {
                Zero(); // call to the event or raise an event
            }
            else if (act_bal < debit_amt)
            {
                Inefficient_bal();
            }
            else
            {
                act_bal -= debit_amt;
                Console.WriteLine($"Your Acount balance is {act_bal}");
            }
        }
        public void Credit(int credit_amt)
        {
            act_bal += credit_amt;
            Console.WriteLine($"Your Acount balance is {act_bal}");
        }

    }
    class EventDelAssignment
    {
        static void ZeroMsg()
        {
            Console.WriteLine("Your Acount Balance is zero.");
        }
        static void Inefficient_balMsg()
        {
            Console.WriteLine("Your Acount has Inefficient Balance.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount");
            int n = Convert.ToInt32(Console.ReadLine());
            Bank b = new Bank(n);
            b.Zero += new Mydel(ZeroMsg);
            b.Inefficient_bal += new Mydel(Inefficient_balMsg);
            Console.WriteLine("Enter Debit Amount");
            int d = Convert.ToInt32(Console.ReadLine());
            b.Debit(d);
            Console.WriteLine("Enter credit Amount");
            int c = Convert.ToInt32(Console.ReadLine());
            b.Credit(c);
            Console.ReadLine();
        }
    }
}
