using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using ReactiveRx.Model;
using ReactiveRx.Repository;

//This Class has a static method that can be callled without instantiation. The small app demonstrate how Reactive extensions can
//be used to work asyncronously and to operate on each element of an object's collection. When Done a message is displayed in the console.

namespace ReactiveRx.RXComputation
{
    class RxComputation
    {      
        private PersonRepository personRepository;
        private IObservable<Person> ObpersonRepository;
        private RxComputation(object param)
        {
            personRepository = new PersonRepository();
            personRepository.LoadFromeRepository();
        }
        public static void Compute(object param) // param can be used to customize the way the repository is loaded 
        {
            // Convert the collection to Observable.
            RxComputation myapp = new RxComputation(param);
            myapp.ObpersonRepository = myapp.personRepository.ToObservable(Scheduler.Default);// Scheduler.Default to obtain the platform's most appropriate pool-based scheduler
            // We subscribe each element of the collection to the ProcessPerson method.
            myapp.ObpersonRepository.Subscribe(myapp.ProcessPerson, myapp.ImDone);// the first method is invoked for every elemet of the collection: the second is invoked when finished
            Console.WriteLine("Main Thread with ThreadID: {0}  is done:", Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine(); // Since the Computation is working on a different thread the Readline instruction prevents the application Ending.
        }
        private void ProcessPerson(Person person)
        {
            Thread.Sleep(1000); // Pausing one second to show how it is working
            // We update the Guid with a new guid and the underlying original collection personRepository is updated accordingly
            person.UniqueID = Guid.NewGuid().ToString();
            Console.WriteLine("{0} Working on Thread {1}", string.Concat(person.FirstName, "   ", person.LastName, "   ", person.UniqueID), Thread.CurrentThread.ManagedThreadId);
        }
        private  void ImDone()
        {
            personRepository.SaveToRepository();
            Console.WriteLine("I am Done and this information is written using Thread:  {0}", Thread.CurrentThread.ManagedThreadId);

        }       
    }
}
