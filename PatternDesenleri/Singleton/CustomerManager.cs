using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //Singleton Pattern kullanım amacı tek bir nesnem olsun mesela ziyaretçi sayısı gibi herkese o an ki sayıyı döndürcek. Tekrar tekrar tanımlanmayacak nesneler için kullanılır.
    class CustomerManager
    {
        private static CustomerManager _customerManager;


        //Öncelikli amaç dışarıdan erişimi engellemek o yüzden constructor'ı private olarak oluşturuyoruz.
        private CustomerManager()
        {

        }

        //Bizim Singleton olarak oluşturulacak metot yazmamız gerek. Bunu da kendi static metodunu oluşturarak yazıyoruz.Statik olduğu için heryerden erişimi olacaktır.

        public static CustomerManager CreateAsSingleton()
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
            //Eğer daha önce customermanager oluşturulduysa bi daha oluşturma onu döndür ama oluşturulmamışsa yeni tanımla ve onu döndür.
            return _customerManager;
        }



        public void Save()
        {
            Console.WriteLine("Deneme");
        }
    }

    class CustomerManager2
    {
        private static CustomerManager2 _cstmanager2;
        public CustomerManager2()
        {

        }

        //Eğer büyük trafiği olan bir site de çalışıyorsanız ve aynı anda iki tane istek gelirse iki nesne oluşur bunun önüne geçmek için önce oluşturma isteği geldiği gibi nesneyi kitleyip ardından kullanıca mesaj döndürüyoruz.Öncelikle object bir nesne oluşturuyoruz.

        static object _lock = new object();

        //Ondan sonra kitlemek için yapmamız gereken lock kodu yazmak.
        public static CustomerManager2 CreateAsSingleton()
        {
            lock (_lock)
            {
                return _cstmanager2 ?? (_cstmanager2 = new CustomerManager2());
            }
                
        }

        // Bu kodun ismi thread safe singleton
    }

}
