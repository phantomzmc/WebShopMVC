using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;
using Purchase._Class;

namespace Purchase
{
    public class _InvoiceList : IDictionary<int, _InvoiceList._Invoice>
    {
        private CStatement _statememet, _statememet2;

        public Dictionary<int, _Invoice> _invoicelist = new Dictionary<int, _Invoice>();

        public DataTable InvoiceAll { get; set; }
        public Int32 ID { get; set; }
        public Int32 PurchaseID { get; set; }
        _Invoice invoice;
        _Purchase _p = new _Purchase();


        public DateTime _Invoice_Date {get; set;}
            public DateTime _GetInvoice_Date {get; set;}
            public DateTime _Transport_Date {get; set;}
            public DateTime _GetGuide {get; set;}
            public DateTime _GetBadge_Date {get; set;}
            public DateTime _NoteSet_Date {get; set;}
            public DateTime _GetNotSet_Date { get; set; }

            public _InvoiceList(DateTime _invoicedate, DateTime _getinvoicedate, DateTime _trandate,DateTime getguide ,DateTime getbadge,DateTime noteset, DateTime getnoteset)
            { 
                _Invoice_Date = _invoicedate;
                _GetInvoice_Date = _getinvoicedate;
                _Transport_Date = _trandate;
                _GetGuide = getguide;
                _GetBadge_Date = getbadge;
                _NoteSet_Date = noteset;
                _GetNotSet_Date = getnoteset;

            }
        

        public _InvoiceList()
        {
            this._statememet = new CStatement("uspSelectInvoice", "uspInsertInvoice", "uspUpdatePurchase", "", System.Data.CommandType.StoredProcedure);
            this._statememet2 = new CStatement("", "", "uspUpdateCarInfo", "", System.Data.CommandType.StoredProcedure);
        }

        public object selectInvoice(int poid)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@POID", DbType.String, poid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;
                InvoiceAll = dt;

                invoice = new _Invoice();
                var item = dt.Rows[0];

                invoice._Invoice_Date = item["Invoice_Date"].ToString() == null || item["Invoice_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["Invoice_Date"].ToString());
                invoice._GetInvoice_Date = item["GetInvoice_Date"].ToString() == null || item["GetInvoice_Date"].ToString() == ""? DateTime.MinValue : DateTime.Parse(item["GetInvoice_Date"].ToString());
                invoice._NoteSet_Date = item["NoteSet_Date"].ToString() == null || item["NoteSet_Date"].ToString() == ""? DateTime.MinValue : DateTime.Parse(item["NoteSet_Date"].ToString());
                invoice._GetNotSet_Date = item["GetNoteSet_Date"].ToString() == null || item["GetNoteSet_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetNoteSet_Date"].ToString());
                invoice._Transport_Date = item["Transport_Date"].ToString() == null || item["Transport_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["Transport_Date"].ToString());
                invoice._GetGuide = item["GetGuide_Date"].ToString() == null || item["GetGuide_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetGuide_Date"].ToString());
                invoice._GetBadge_Date = item["GetBadge_Date"].ToString() == null || item["GetBadge_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetBadge_Date"].ToString());
                invoice._RemarkInvoice = item["RemarkInvoice"].ToString() == string.Empty || item["RemarkInvoice"].ToString() == "" ? "-" : item["RemarkInvoice"].ToString();

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
            return result;
        }

        public DataTable selectInvoiceReport(int poid)
        {
            //object result = null;
            DataTable _dt = new DataTable();
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@POID", DbType.String, poid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                _dt = (DataTable)cstate.Execute(adlist);
                //DataTable dt = (DataTable)result;
                InvoiceAll = _dt;

                invoice = new _Invoice();
                var item = _dt.Rows[0];

                invoice._Invoice_Date = item["Invoice_Date"].ToString() == null || item["Invoice_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["Invoice_Date"].ToString());
                invoice._GetInvoice_Date = item["GetInvoice_Date"].ToString() == null || item["GetInvoice_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetInvoice_Date"].ToString());
                invoice._NoteSet_Date = item["NoteSet_Date"].ToString() == null || item["NoteSet_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["NoteSet_Date"].ToString());
                invoice._GetNotSet_Date = item["GetNoteSet_Date"].ToString() == null || item["GetNoteSet_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetNoteSet_Date"].ToString());
                invoice._Transport_Date = item["Transport_Date"].ToString() == null || item["Transport_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["Transport_Date"].ToString());
                invoice._GetGuide = item["GetGuide_Date"].ToString() == null || item["GetGuide_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetGuide_Date"].ToString());
                invoice._GetBadge_Date = item["GetBadge_Date"].ToString() == null || item["GetBadge_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetBadge_Date"].ToString());
                invoice._RemarkInvoice = item["RemarkInvoice"].ToString() == string.Empty || item["RemarkInvoice"].ToString() == "" ? "-" : item["RemarkInvoice"].ToString();

                //_InvoiceList invoice = new _InvoiceList(_invoicedate, _getinvoicedate, _trandate, _getguide, _getbadge, _noteset, _getnoteset);

                //this._invoicelist = dt.ToDictionary<int, _Invoice>("PurchaseID");
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
            return _dt;
        }
        public void insertInvoice(int poid, string invoice_date, string getinvoice_date, string tran_date, string getguide_date, string getbadge_date, string noteset_date, string getnoteset_date,string remarkInvoice)
        {
            //DateTime minValue = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;

            invoice._Invoice_Date = (invoice_date == string.Empty || invoice_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(invoice_date.ToString());
            invoice._GetInvoice_Date = (getinvoice_date == string.Empty || getinvoice_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getinvoice_date.ToString());
            invoice._Transport_Date = (tran_date == string.Empty || tran_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(tran_date.ToString());
            invoice._GetGuide = (getguide_date == string.Empty || getguide_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getguide_date.ToString());
            invoice._GetBadge_Date = (getbadge_date == string.Empty || getbadge_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getbadge_date.ToString());
            invoice._NoteSet_Date = (noteset_date == string.Empty || noteset_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(noteset_date.ToString());
            invoice._GetNotSet_Date = (getnoteset_date == string.Empty || getnoteset_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getnoteset_date.ToString());
            invoice._RemarkInvoice = (remarkInvoice.ToString() == string.Empty || remarkInvoice.ToString() == "-") ? string.Empty : remarkInvoice.ToString();

            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@ID", DbType.Int32, poid, ParameterDirection.Input);
                plist.Add("@Invoice_Date", DbType.Date, invoice._Invoice_Date, ParameterDirection.Input);
                plist.Add("@GetInvoice_Date", DbType.Date, invoice._GetInvoice_Date, ParameterDirection.Input);
                plist.Add("@Transport_Date", DbType.Date, invoice._Transport_Date, ParameterDirection.Input);
                plist.Add("@GetGuide_Date", DbType.Date, invoice._GetGuide, ParameterDirection.Input);
                plist.Add("@GetBadge_Date", DbType.Date, invoice._GetBadge_Date, ParameterDirection.Input);
                plist.Add("@NoteSet_Date", DbType.Date, invoice._NoteSet_Date, ParameterDirection.Input);
                plist.Add("@GetNoteSet_Date", DbType.Date, invoice._GetNotSet_Date, ParameterDirection.Input);
                plist.Add("@RemarkInvoice", DbType.String, invoice._RemarkInvoice, ParameterDirection.Input);
                plist.Add("@PurchaseID", DbType.Int32, poid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);
                //this._invoicelist = dt.ToDictionary<int, _Invoice>("PurchaseID");
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

        public void editInvoice(int poid, string invoice_date, string getinvoice_date, string tran_date, string getguide_date, string getbadge_date, string noteset_date, string getnoteset_date,string remarkInvoice)
        //public void editInvoice(int poid)
        {
            //DateTime minValue = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
            //DateTime? TimeTo;
            var dt = InvoiceAll;
            var row = dt.Rows[0];

            invoice._Invoice_Date = (invoice_date == string.Empty || invoice_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(invoice_date.ToString());
            invoice._GetInvoice_Date = (getinvoice_date == string.Empty || getinvoice_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getinvoice_date.ToString());
            invoice._Transport_Date = (tran_date == string.Empty || tran_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(tran_date.ToString());
            invoice._GetGuide = (getguide_date == string.Empty || getguide_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getguide_date.ToString());
            invoice._GetBadge_Date = (getbadge_date == string.Empty || getbadge_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getbadge_date.ToString());
            invoice._NoteSet_Date = (noteset_date == string.Empty || noteset_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(noteset_date.ToString());
            invoice._GetNotSet_Date = (getnoteset_date == string.Empty || getnoteset_date == "ไม่ระบุ") ? DateTime.MinValue : Convert.ToDateTime(getnoteset_date.ToString());
            invoice._RemarkInvoice = (remarkInvoice == string.Empty || remarkInvoice == "ไม่ระบุ") ? String.Empty : remarkInvoice.ToString();

            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@POID", DbType.Int32, poid, ParameterDirection.Input);
                plist.Add("@Invoice_Date", DbType.Date, invoice._Invoice_Date, ParameterDirection.Input);
                plist.Add("@GetInvoice_Date", DbType.Date, invoice._GetInvoice_Date, ParameterDirection.Input);
                plist.Add("@Transport_Date", DbType.Date, invoice._Transport_Date, ParameterDirection.Input);
                plist.Add("@GetGuide_Date", DbType.Date, invoice._GetGuide, ParameterDirection.Input);
                plist.Add("@GetBadge_Date", DbType.Date, invoice._GetBadge_Date, ParameterDirection.Input);
                plist.Add("@NoteSet_Date", DbType.Date, invoice._NoteSet_Date, ParameterDirection.Input);
                plist.Add("@GetNoteSet_Date", DbType.Date, invoice._GetNotSet_Date, ParameterDirection.Input);
                plist.Add("@RemarkInvoice", DbType.String, invoice._RemarkInvoice, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Update);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);
                //this._invoicelist = dt.ToDictionary<int, _Invoice>("PurchaseID");
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

        public void updateCarInfo(int poid,string carplate,DateTime _RegisDate,string cartax , int cartype)
        {


            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@POID", DbType.Int32, poid, ParameterDirection.Input);
                plist.Add("@CarPlate", DbType.String, carplate, ParameterDirection.Input);
                plist.Add("@Regis_Date", DbType.Date, _RegisDate, ParameterDirection.Input);
                plist.Add("@CarTax", DbType.String, cartax, ParameterDirection.Input);
                plist.Add("@CarType", DbType.Int32, cartype, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet2, plist, NoomLibrary.StatementType.Update);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);
                //this._invoicelist = dt.ToDictionary<int, _Invoice>("PurchaseID");
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

        #region Imprement
        public void Add(int key, _InvoiceList._Invoice value)
        {
            this._invoicelist.Add(key, value);
        }

        public bool ContainsKey(int key)
        {
            return this._invoicelist.ContainsKey(key);
        }

        public ICollection<int> Keys
        {
            get
            {
                ICollection<int> keys = new List<int>();
                foreach (int item in this._invoicelist.Keys)
                {
                    keys.Add(item);
                }
                return keys;
            }
        }

        public bool Remove(int key)
        {
            return this._invoicelist.Remove(key);
        }

        public bool TryGetValue(int key, out _InvoiceList._Invoice value)
        {
            return this._invoicelist.TryGetValue(key, out value);
        }

        public ICollection<_InvoiceList._Invoice> Values
        {

            get
            {
                ICollection<_Invoice> values = new List<_Invoice>();
                foreach (_Invoice item in this._invoicelist.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _InvoiceList._Invoice this[int key]
        {
            get
            {
                _Invoice result;
                if (this._invoicelist.TryGetValue(key, out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Invoice result;
                if (this._invoicelist.TryGetValue(key, out result))
                {
                    this._invoicelist[key] = value;
                }
                else
                {
                    this._invoicelist.Add(key, value);
                }
            }
        }

        public void Add(KeyValuePair<int, _InvoiceList._Invoice> item)
        {
            this._invoicelist.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._invoicelist.Clear();
        }

        public bool Contains(KeyValuePair<int, _Invoice> item)
        {
            _Invoice value;
            if (!this._invoicelist.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Invoice>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _InvoiceList._Invoice>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this._invoicelist.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<int, _InvoiceList._Invoice> item)
        {
            return this._invoicelist.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _InvoiceList._Invoice>> GetEnumerator()
        {
            return this._invoicelist.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._invoicelist.GetEnumerator();
        }
        #endregion

        public class _Invoice
        {
            private CStatement _statememetInvoice;

            public Int32 _ID {get; set;}
            public DateTime _Invoice_Date {get; set;}
            public DateTime _GetInvoice_Date {get; set;}
            public DateTime _Transport_Date {get; set;}
            public DateTime _GetGuide {get; set;}
            public DateTime _GetBadge_Date {get; set;}
            public DateTime _NoteSet_Date {get; set;}
            public DateTime _GetNotSet_Date { get; set; }
            public String _RemarkInvoice { get; set; }
            public Int32 _PurchaseID { get; set; }

            public _Invoice()
            {
                this._statememetInvoice = new CStatement("uspSelectInvoice", "uspInsertInvoice", "uspUpdatePurchase", "", System.Data.CommandType.StoredProcedure);
                _Invoice_Date = DateTime.MinValue;
                _GetInvoice_Date = DateTime.MinValue;
                _Transport_Date = DateTime.MinValue;
                _GetGuide = DateTime.MinValue;
                _GetBadge_Date = DateTime.MinValue;
                _NoteSet_Date = DateTime.MinValue;
                _GetNotSet_Date = DateTime.MinValue;
                _RemarkInvoice = String.Empty;

            }

            public object selectInvoice(int poid)
            {
                object result = null;
                CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@POID", DbType.String, poid, ParameterDirection.Input);

                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csv = new CSQLStatementValue(this._statememetInvoice, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csv);
                    cstate.Open();

                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    var item = dt.Rows[0];

                    _Invoice_Date = item["Invoice_Date"].ToString() == null || item["Invoice_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["Invoice_Date"].ToString());
                    _GetInvoice_Date = item["GetInvoice_Date"].ToString() == null || item["GetInvoice_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetInvoice_Date"].ToString());
                    _NoteSet_Date = item["NoteSet_Date"].ToString() == null || item["NoteSet_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["NoteSet_Date"].ToString());
                    _GetNotSet_Date = item["GetNoteSet_Date"].ToString() == null || item["GetNoteSet_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetNoteSet_Date"].ToString());
                    _Transport_Date = item["Transport_Date"].ToString() == null || item["Transport_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["Transport_Date"].ToString());
                    _GetGuide = item["GetGuide_Date"].ToString() == null || item["GetGuide_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetGuide_Date"].ToString());
                    _GetBadge_Date = item["GetBadge_Date"].ToString() == null || item["GetBadge_Date"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(item["GetBadge_Date"].ToString());
                    _RemarkInvoice = item["RemarkInvoice"].ToString() == string.Empty || item["RemarkInvoice"].ToString() == "" ? "-" : item["RemarkInvoice"].ToString();

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
                return result;
            }
            
        }
    }

}