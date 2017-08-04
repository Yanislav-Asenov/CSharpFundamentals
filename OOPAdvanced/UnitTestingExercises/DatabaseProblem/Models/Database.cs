namespace DatabaseProblem.Models
{
    using System;
    using DatabaseProblem.Contracts;
    using System.Linq;
    using System.Collections.Generic;

    public class Database : IDatabase
    {
        private IList<IPerson> people;

        public Database()
        {
            this.people = new List<IPerson>();
        }

        public Database(params IPerson[] items)
        {
            this.people = new List<IPerson>(items);
        }
        
        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public IPerson FindById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            IPerson targetPerson = this.people.FirstOrDefault(p => p.Id == id);

            if (targetPerson == null)
            {
                throw new InvalidOperationException();
            }

            if (targetPerson.Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        
            return targetPerson;
        }

        public IPerson FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidOperationException();
            }

            IPerson targetPerson = this.people.FirstOrDefault(p => p.Username == username);

            if (targetPerson == null)
            {
                throw new InvalidOperationException();
            }

            return targetPerson;
        }

        public IPerson[] GetAll()
        {
            return this.people.ToArray();
        }

        public IPerson Remove()
        {
            if (this.people.Count == 0)
            {
                throw new InvalidOperationException();
            }

            IPerson itemToReturn = this.people[this.people.Count - 1];
            this.people.RemoveAt(this.people.Count - 1);

            return itemToReturn;
        }
    }
}
