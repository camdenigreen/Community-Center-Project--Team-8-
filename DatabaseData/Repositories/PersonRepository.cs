﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DatabaseData.DataDelagates;
using DatabaseData.DataDelegates;

namespace DatabaseData
{
    public class PersonRepository : IPersonRepository
    {
        private readonly CommandExecutor _executor;

        public PersonRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

        public Person CreatePerson(string firstName, string lastName, string address, string phoneNumber, byte isMember)
        {
            CreatePersonDataDelegate data = new CreatePersonDataDelegate(firstName, lastName, phoneNumber, address, isMember);
       
            return _executor.ExecuteNonQuery(data);
        }

        public Person FetchPerson(int personId)
        {
            FetchPersonDataDelegate data = new FetchPersonDataDelegate(personId);
            return _executor.ExecuteReader(data);
        }

        public void UpdateMembership(int personId)
        {
            UpdateMembershipDataDelegate data = new UpdateMembershipDataDelegate(personId);
             _executor.ExecuteNonQuery(data);
        }

        public IReadOnlyList<Person> RetrievePersons(string phoneNumber, string lastName)
        {
            RetrieveAllMembersDataDelegate data = new RetrieveAllMembersDataDelegate(phoneNumber, lastName);
            return _executor.ExecuteReader(data);
        }

        public Person GetPerson(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Person> RetrievePersons()
        {
            RetrieveAllMembersDataDelegate data = new RetrieveAllMembersDataDelegate(null,null);
            return _executor.ExecuteReader(data);
        }
        public void UpdateInformation(int id, string address,string firstName,string lastName, string phoneNumber)
        {
            UpdateInformationDataDelegate data = new UpdateInformationDataDelegate(id, address, firstName, lastName, phoneNumber);
            _executor.ExecuteNonQuery(data);

        }
        public IReadOnlyList<PersonBalance> RetrieveNegativeBalances()
        {
            RetrieveNegativeBalancesDataDelegate data = new RetrieveNegativeBalancesDataDelegate();
            return _executor.ExecuteReader(data);
        }

       
    }
}
