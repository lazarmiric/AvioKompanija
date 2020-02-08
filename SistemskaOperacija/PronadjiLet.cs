using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioKompanija;

namespace SistemskaOperacija
{
    public class PronadjiLet : OpstaSistemskaOperacija
    {
        public Let Let { get; private set; }
        protected override object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Let l = (Let)objekat;
            Let = l;
            return broker.Pronadji(objekat).OfType<Let>().ToList();
        }
        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Let))
            {
                throw new ArgumentException();
            }
        }
    }
}
