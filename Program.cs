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
using ReactiveRx.RXComputation;

namespace ReactiveRXonCollections
{
    class Program
    {   
        static void Main(string[] args)
        {
            RxComputation.Compute(null);
        }
    }
}
