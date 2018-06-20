/*
 * работа службы, которая следит за нарушениями в поведении собак - оповещает владельцев и штрафует их
 * у одного владельца может быть несколько собак
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverDog
{
    public delegate void NotifyObserverEventHandler(Dog dog, string message);

    public interface ISubject
    {
        event NotifyObserverEventHandler Notify;
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }

    public class Dog : ISubject // издатель
    {
        public event NotifyObserverEventHandler Notify;

        public string Name { set; get; }

        public Dog(string name)
        {
            Name = name;
        }

        // оповещение всех подписавшихся о произошедшем событии
        public void Shit(string message)
        {
            if (Notify != null) // если есть подписчики
                Notify(this, message);
        }

        public void AddObserver(IObserver observer)
        {// присоединение обработчика события к событию
            this.Notify += observer.Update; // подписка на событие
        }

        public void RemoveObserver(IObserver observer)
        {
            this.Notify -= observer.Update; // отмена подписки на событие
        }
    }

    public interface IObserver
    {
        void Update(Dog dog, string message);
    }

    class Service : IObserver // подписчик
    {
        private Dictionary<string, List<Dog>> serviceList = new Dictionary<string, List<Dog>>();

        public void AddInfo(string owner, Dog dog)
        {
            bool truth = false;

            foreach (var list in serviceList)
                if (list.Key == owner) // если в списке есть владелец
                {
                    list.Value.Add(dog); // добавляем собаку
                    truth = true;
                    break;
                }

            if (!truth)
                serviceList.Add(owner, new List<Dog> { dog }); // добавляю нового владельца
        }

        public void Update(Dog dog, string message)
        {
            Console.WriteLine(String.Format("Служба: собака {0} {1}\n", dog.Name, message));

            foreach (var list in serviceList)
            {
                foreach (Dog d in list.Value)
                    if (d == dog) // если есть совпадение собаки
                        break;

                Console.WriteLine(String.Format("{0} с Вас штраф 100 грн.", list.Key));
                break;
            }
        }
    }

    class Owner
    {
        public string Name { set; get; }

        public Owner(string name)
        {
            Name = name;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Service ATF = new Service();

            Owner Vanya = new Owner("Vanya");

            Dog Bobik = new Dog("Bobik");
            ATF.AddInfo(Vanya.Name, Bobik);
            Bobik.AddObserver(ATF);

            Dog Sharik = new Dog("Sharik");
            ATF.AddInfo(Vanya.Name, Sharik);
            Sharik.AddObserver(ATF);

            Bobik.Shit("пок...ла"); // инициализация события
            Sharik.Shit("гавкала");

            Console.ReadKey();
        }
    }
}