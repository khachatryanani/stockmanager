using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
 
namespace FrontEnd_Desktop.MVVM.Model
{
    public class WorkerModel
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public WorkerModel(Worker worker)
        {
            this.WorkerId = worker.WorkerId;
            this.Name = worker.Name;
            this.Surname = worker.Surname;
            this.Email = worker.Email;
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }
    }
}
