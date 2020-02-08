using AvioKompanija;
using BrokerBaze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskaOperacija
{
    
        public abstract class OpstaSistemskaOperacija
        {
              protected Broker broker = new Broker();
              protected abstract void Validacija(IDomenskiObjekat objekat);
              protected abstract object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat);            
              public object Izvrsi(IDomenskiObjekat objekat)
              {
                try
                {
                    Validacija(objekat);
                    broker.OtvoriKonekciju();
                    broker.PokreniTransakciju();
                    object rezultat = IzvrsiKonkretnuOperaciju(objekat);
                    broker.Commit();
                    return rezultat;
                }
                catch (Exception e)
                {
                String s = e.Message;
                
                broker.Rollback();
                return null;
                throw;


            }
                finally
                {
                    broker.ZatvoriKonekciju();
                }
            
        }
    }
}
