﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioKompanija;

namespace SistemskaOperacija
{
    public class ZapamtiLet : OpstaSistemskaOperacija
    {
        public Let Let { get; private set; }
        protected override object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Let l = (Let)objekat;
            Let = l;
            return broker.sacuvaj(objekat);
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
