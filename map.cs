using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp83
{
    
    public class BankData
    {
        private List<Client<string,long>> _clients = new List<Client<string, long>>();
   
        public void Add(string name, long money)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (money == null)
            {
                throw new ArgumentNullException(nameof(money));
            }
            var client = new Client<string, long>()
            {
                clientName = name,
                clientMoney = money
            };
            if (!_clients.Any(i => i.clientName.Equals(client.clientName)))
            {
                _clients.Add(client);
            }
            else
            {
             var update = _clients.SingleOrDefault(i => i.clientName.Equals(name));
             update.clientMoney += money;
            }
            
        }

        public void CurrentClient(string name)
        {
            if (_clients.Any(i => i.clientName.Equals(name)))
            {
                var client = _clients.SingleOrDefault(i => i.clientName.Equals(name));

                Console.WriteLine(client.clientMoney);
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }



    }

    public class Client<TKey, TValue>
    {
        public TKey clientName { get; set; }
        public TValue clientMoney { get; set; }
        public override int GetHashCode()
        {
            int result = 17;
            result = -13 * result +
                     (clientName == null ? 0 : clientName.GetHashCode());
            result = -13 * result +
                     (clientMoney == null ? 0 : clientMoney.GetHashCode());
            return result;
        }
        public override bool Equals(object other)
        {
            return Equals(other as Client<TKey,TValue>);
        }
        public Client(){}

        public Client(TKey name,TValue money)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (money == null)
            {
                throw new ArgumentNullException(nameof(money));
            }

            clientName = name;
            clientMoney = money;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            BankData bank = new BankData();
            
            for (int i = 0; i < N; i++)
            {

                string[] str = Array.ConvertAll(Console.ReadLine().Split(), element => element.ToString());
              

                if (str[0].Equals("1"))
                {
                  bank.Add(str[1],Convert.ToInt64(str[2]));
                }
                else if (str[0].Equals("2"))
                {
                   bank.CurrentClient(str[1]);
                }
               

            }
        }
    }
}
