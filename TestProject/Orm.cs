using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Orm : IDisposable
    {
        
        public Database database;

        public Orm(Database database)
        {
            this.database = database;
        }


        public void Begin()
        {
          this.database.BeginTransaction();
        }

        public void Write(string data)
        {
            try
            {
                this.database.Write(data);
            }
            catch (Exception ex)
            {
                Dispose();
            }
           
        }

        public void Commit()
        {
            try
            {
                this.database.EndTransaction();
            }
            catch(Exception ex)
            {
                Dispose()
            }
        }

        public void Dispose()
        {
            this.database.Dispose();
        }
    }
}
