using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using Microsoft.Win32;

namespace db_project
{
    public class Database
    {
        public DataSet xml = new DataSet();

        public NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;
        //TODO если нет соединения - работать оффлайн с локальным массивом и возможностью передачи его в XML

        public bool InitializeConnection(string host, string port, string user, string pwd, string db)
        {
            string connectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", host, port, user, pwd, db);

            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                connection = null;
                return false;
            }
                        
            return true;
        }
        public bool InitializeDefaultConnection()
        {
            string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=artist_database;";

            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ExecuteNonQuery(string queryString)
        {
            NpgsqlCommand command = new NpgsqlCommand(queryString, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public DataView ExecuteQuery(string queryString)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(queryString, connection);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch
            {
                return null;
            }
            DataTable dt = ds.Tables[0];
            return dt.DefaultView;
        }

        public  DataView LoadTable(string table)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * from " + table, connection);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt.DefaultView;
        }

        public DataView LoadTable(string fields, string tables, string where)
        {
            string queryString = String.Format("SELECT {0} FROM {1} WHERE {2}", fields, tables, where);
            return ExecuteQuery(queryString);
        }

        public DataView LoadTable(string fields, string tables, string where, string order)
        {
            string queryString = String.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3}", fields, tables, where, order);
            return ExecuteQuery(queryString);
        }

        public bool CreateEntity(string tables, string fields, string values)
        {
            //проверка на добавление уже существующего
            string query = String.Format("INSERT INTO public.{0} ({1}) VALUES ({2});", tables, fields, values);
            return ExecuteNonQuery(query);
        }

        public bool UpdateEntity(string table, string fields, string fieldsValues, string idField, string id)
        {
            string query = String.Format("UPDATE {0} SET ({1}) = ({2}) WHERE {3} = {4}", table, fields, fieldsValues, idField, id);
            return ExecuteNonQuery(query);
        }

        public bool DeleteEntity(string table, string idField, string id)
        {
            string query = String.Format("DELETE FROM {0} WHERE ({1}) = ({2});", table, idField, id);
            return ExecuteNonQuery(query);
        }


        //Transations
        public void BeginTransaction()
        {
            if (InTransaction())
                EndTransaction(false);

            transaction = connection.BeginTransaction();
        }

        public bool InTransaction()
        {
            return transaction != null;
        }

        public void EndTransaction(bool commit)
        {
            if (commit)
                transaction.Commit();
            else
                transaction.Rollback();
            transaction = null;
        }

        //XML
        public bool exportXML(string setName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML|*.xml";
            string fname;
            if (saveFileDialog.ShowDialog() == true)
            {
                fname = saveFileDialog.FileName;
                xml.WriteXml(fname);
                xml.WriteXmlSchema(fname + "_shema.xml");
                return true;
            }
            return false;
        }

        public bool importXML(string setName)
        {
            xml = new DataSet();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML|*.xml";
            string fname;
            if (openFileDialog.ShowDialog() == true)
            {
                fname = openFileDialog.FileName;
                try
                {
                    xml.ReadXmlSchema(fname + "_shema.xml");
                }
                catch
                { }

                xml.ReadXml(fname);
                if (xml.DataSetName != setName)
                {
                    xml = new System.Data.DataSet();
                    return false;
                }

                return true;
            }

            return false;
        }

    }
}
