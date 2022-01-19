using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitolo8
{
    interface IMyDocument
    {
        void Print();
        void Save();
    }

    abstract class AbstractDocument : IMyDocument
    {
        public abstract void Print();
        public virtual void Save()
        {
            Console.WriteLine("Save");
        }
    }

    class MyDoc : AbstractDocument
    {
        public override void Print()
        {
            Console.WriteLine("Print");
        }

    }

}
