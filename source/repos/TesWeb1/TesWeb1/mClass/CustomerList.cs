using NoomLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TesWeb1
{
    public class CustomerDic : IDictionary<int, CustomerDic.Customer>
    {
        private CStatement _statememet;

        public Dictionary<int, CustomerDic.Customer> _customer = new Dictionary<int, CustomerDic.Customer>();

        public CustomerDic()
        {
            this._statememet = new CStatement("uspSelectUser", "", "", "", System.Data.CommandType.StoredProcedure);
        }
        public void selectCustomer(int userid)
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@UserID", DbType.Int32, userid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this._customer = dt.ToDictionary<int, Customer>("UserID");
                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }

        #region
        public Customer this[int key] { get => ((IDictionary<int, Customer>)_customer)[key]; set => ((IDictionary<int, Customer>)_customer)[key] = value; }

        public ICollection<int> Keys => ((IDictionary<int, Customer>)_customer).Keys;

        public ICollection<Customer> Values => ((IDictionary<int, Customer>)_customer).Values;

        public int Count => ((IDictionary<int, Customer>)_customer).Count;

        public bool IsReadOnly => ((IDictionary<int, Customer>)_customer).IsReadOnly;

        public void Add(int key, Customer value)
        {
            ((IDictionary<int, Customer>)_customer).Add(key, value);
        }

        public void Add(KeyValuePair<int, Customer> item)
        {
            ((IDictionary<int, Customer>)_customer).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<int, Customer>)_customer).Clear();
        }

        public bool Contains(KeyValuePair<int, Customer> item)
        {
            return ((IDictionary<int, Customer>)_customer).Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return ((IDictionary<int, Customer>)_customer).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, Customer>[] array, int arrayIndex)
        {
            ((IDictionary<int, Customer>)_customer).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<int, Customer>> GetEnumerator()
        {
            return ((IDictionary<int, Customer>)_customer).GetEnumerator();
        }

        public bool Remove(int key)
        {
            return ((IDictionary<int, Customer>)_customer).Remove(key);
        }

        public bool Remove(KeyValuePair<int, Customer> item)
        {
            return ((IDictionary<int, Customer>)_customer).Remove(item);
        }

        public bool TryGetValue(int key, out Customer value)
        {
            return ((IDictionary<int, Customer>)_customer).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<int, Customer>)_customer).GetEnumerator();
        }


        #endregion
        public class Customer
        {
            public int UserID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Tel { get; set; }
            public string Gender { get; set; }
            public string NumAddress { get; set; }
            public string Tambon { get; set; }
            public string Amphoe { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string PostNumber { get; set; }
            public string BrithDay { get; set; }

            public Customer() { }

        }
    }

}