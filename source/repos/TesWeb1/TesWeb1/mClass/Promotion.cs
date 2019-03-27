using NoomLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TesWeb1
{
    public class PromotionList : IDictionary<int, PromotionList.Promotion>
    {
        private CStatement _statememet, _statememet2,_searchPromotion;

        public Dictionary<int, PromotionList.Promotion> _promotionlist = new Dictionary<int, Promotion>();

        public PromotionList()
        {
            this._statememet = new CStatement("uspGetPromotion", "uspAddPromotion", "uspUpdatePromotion", "uspDelPromotion", System.Data.CommandType.StoredProcedure);
            this._statememet2 = new CStatement("uspSelectPromotion", "", "", "", System.Data.CommandType.StoredProcedure);
            this._searchPromotion = new CStatement("uspSearchPromotion", "", "", "", System.Data.CommandType.StoredProcedure);

        }
        public DataTable PromotionAll { get; set; }

        public void selectPromotion()
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this._promotionlist = dt.ToDictionary<int, Promotion>("PromotionID");
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
        public void addPromotion(string promotionname,string promotiondiscount , int promotiontype)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@PromotionName", DbType.String, promotionname, ParameterDirection.Input);
                plist.Add("@PromotionDiscount", DbType.String, promotiondiscount, ParameterDirection.Input);
                plist.Add("@PromotionType", DbType.Int32, promotiontype, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);
                
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
        public void editPromotion(int promotionid, string promotionname, string promotiondiscount, int promotiontype)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@PromotionID", DbType.Int32, promotionid, ParameterDirection.Input);
                plist.Add("@PromotionName", DbType.String, promotionname, ParameterDirection.Input);
                plist.Add("@PromotionDiscount", DbType.String, promotiondiscount, ParameterDirection.Input);
                plist.Add("@PromotionType", DbType.Int32, promotiontype, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Update);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void deletePromotion(int promotionid)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@PromotionID", DbType.Int32, promotionid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Delete);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void getPromotion(int promotionid)
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@PromotionID", DbType.Int32, promotionid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet2, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                //this._promotionlist = dt.ToDictionary<int, Promotion>("PromotionID");
                PromotionAll = dt;
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
        public void searchPromotion(string keyname)
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@KeyName", DbType.String, keyname, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._searchPromotion, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this._promotionlist = dt.ToDictionary<int, Promotion>("PromotionID");
                PromotionAll = dt;
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

        #region imprement
        public Promotion this[int key] { get => ((IDictionary<int, Promotion>)_promotionlist)[key]; set => ((IDictionary<int, Promotion>)_promotionlist)[key] = value; }

        public ICollection<int> Keys => ((IDictionary<int, Promotion>)_promotionlist).Keys;

        public ICollection<Promotion> Values => ((IDictionary<int, Promotion>)_promotionlist).Values;

        public int Count => ((IDictionary<int, Promotion>)_promotionlist).Count;

        public bool IsReadOnly => ((IDictionary<int, Promotion>)_promotionlist).IsReadOnly;

        public void Add(int key, Promotion value)
        {
            ((IDictionary<int, Promotion>)_promotionlist).Add(key, value);
        }

        public void Add(KeyValuePair<int, Promotion> item)
        {
            ((IDictionary<int, Promotion>)_promotionlist).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<int, Promotion>)_promotionlist).Clear();
        }

        public bool Contains(KeyValuePair<int, Promotion> item)
        {
            return ((IDictionary<int, Promotion>)_promotionlist).Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return ((IDictionary<int, Promotion>)_promotionlist).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, Promotion>[] array, int arrayIndex)
        {
            ((IDictionary<int, Promotion>)_promotionlist).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<int, Promotion>> GetEnumerator()
        {
            return ((IDictionary<int, Promotion>)_promotionlist).GetEnumerator();
        }

        public bool Remove(int key)
        {
            return ((IDictionary<int, Promotion>)_promotionlist).Remove(key);
        }

        public bool Remove(KeyValuePair<int, Promotion> item)
        {
            return ((IDictionary<int, Promotion>)_promotionlist).Remove(item);
        }

        public bool TryGetValue(int key, out Promotion value)
        {
            return ((IDictionary<int, Promotion>)_promotionlist).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<int, Promotion>)_promotionlist).GetEnumerator();
        }

        #endregion

        public class Promotion
        {
            public int PromotionID { get; set; }
            public string PromotionName { get; set; }
            public string PromotionDiscount { get; set; }
            public string PromotionType { get; set; }

            public Promotion(string promodis,string promotype,string proname) { }

            public Promotion()
            {
            }
        }
    }
    
}