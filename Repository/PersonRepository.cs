using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveRx.Model;

using System.Threading;

namespace ReactiveRx.Repository
{
    public   class PersonRepository:List<Person>
    {
      
        public PersonRepository()
        {            

        }

        public void LoadFromeRepository()
        {
            this.Add(new Person { FirstName = "Diego", LastName = "Burlando", UniqueID = null });
            this.Add(new Person { FirstName = "Maria", LastName = "Burlando", UniqueID = null });
            this.Add(new Person { FirstName = "Marco", LastName = "Anselmi", UniqueID = null });
            this.Add(new Person { FirstName = "Elizabeth", LastName = "Green", UniqueID = null });
        }


        public void SaveToRepository()
        {
            // To implement
        }




    }
}
