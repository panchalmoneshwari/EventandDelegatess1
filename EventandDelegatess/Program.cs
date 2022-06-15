using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventandDelegatess
{
    //delegate is ref type in c#,it is type,declare inside namespace
    public delegate void Mydel1(string a);
    public class strmanupulation
    {
        public void Uppercase(string name)
        {
            Console.WriteLine(name.ToUpper());
        }
        public void Lowercase(string name)
        {
            Console.WriteLine(name.ToLower());
        }
    }
    class Case_change
    {
        static void Main(string[] args)
        {
            strmanupulation str = new strmanupulation();
            Mydel1 obj = new Mydel1(str.Uppercase);
            obj += new Mydel1(str.Lowercase);//Add the method in invocation list
            obj -= new Mydel1(str.Uppercase);//Remove the method from invocation list
            //obj.Invoke("India");
            Delegate[] list = obj.GetInvocationList();
            foreach (Delegate a in list)
            {
                Console.WriteLine(a.Method);
                a.DynamicInvoke("Pune");
            }
            Console.ReadLine();
        }
    }
    class Program
    {
        
        public class Student
        {
            public event Mydel Fail;
            public event Mydel Distinction;
            public void AcceptMarks(int marks)
            {
                if (marks < 40)
                {
                    Fail(); // call to the event or raise an event
                }
                else if (marks >= 75)
                {
                    Distinction();
                }
                Console.WriteLine($"Your Score is {marks}");
            }
        }
        class Result
        {
            static void FailMsg()
            {
                Console.WriteLine("You are fail !");
            }
            static void DistinctionMsg()
            {
                Console.WriteLine("Congratulations ! You are pass with Distinction");
            }
            static void Main(string[] args)
            {
                Student s1 = new Student();
                s1.Fail += new Mydel(FailMsg);
                s1.Distinction += new Mydel(DistinctionMsg);
                s1.AcceptMarks(30);
                Console.ReadLine();
            }

        }


    }
   
}
