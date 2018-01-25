using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
   
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customer = new CustomerManager();//Bu şekilde çağırmak mümkün olmayacaktır.Eğer oluşturmak istersek

           var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();//Bu şekilde içindeki işleme erileşebilir.
        }
    }
}
