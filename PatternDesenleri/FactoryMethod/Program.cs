using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    //En çok kullanılan desing patternlerden biridir.Amaç yazılımı kontrol altına almaktır.

    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customer = new CustomerManager(new LoggerFactory2());// Hangi fabrikayı kullanmak istersen onu çağırıyorsun
            customer.Save();

        }
    }
    //1.Fabrikam
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Fabrika sonunda hangi log çalışcaksa o üretilir.
            return new TkLogger();
        }
    }

    //2.Fabrikam
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new TkLogger2();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    //İşçiler 
    public class TkLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("1. Fabrika Logu");
        }
    }

    public class TkLogger2 : ILogger
    {
        public void Log()
        {
            Console.WriteLine("2.Fabrika Logu");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerfactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerfactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Kaydet");
            ILogger logger = _loggerfactory.CreateLogger();// new keywordü yerine loggerfactory'i bağımsız yaptık.Bu şekilde fabrikalarla olan bağlantıyı kestik tek fabrikaya bağımlı kalmadık.
            logger.Log();
        }
    }
}
