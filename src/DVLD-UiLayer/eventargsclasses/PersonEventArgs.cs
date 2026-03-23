using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD_UiLayer.EventArgsClasses
{
    public class PersonEventArgs : EventArgs
    {
        public readonly clsPerson Person;
        public PersonEventArgs(clsPerson person)
        {
            this.Person = person;
        }

    }

}
