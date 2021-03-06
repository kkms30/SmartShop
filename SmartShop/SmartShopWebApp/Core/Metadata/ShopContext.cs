﻿using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace SmartShopWebApp.Core.GeneratedModels
{
    // ROZSZRZENIE KLASY SHOP CONTEXT - SPOWODOWANE NADPISYWANIEM KLASY SHOP CONTEXT PRZEZ ENTITY FRAMEWORK
    // PRZY KAZDEJ AKTUALIZACJI MODELU Z BAZY DANYCH
    public partial class ShopContext
    {
        // METODA WYMUSZA ODSWIEZENIE ENCJI TRANSAKCJI PO DODANIU JEJ DO BAZY
        // BEZ NIEJ NIE ODSWIEZA SIE IdTransaction      
        public override int SaveChanges()
        {
            var entriesToReload = ChangeTracker.Entries<Transaction>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            int rowCount = 0;

            try
            {
                rowCount = base.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Wyłapałem wyjątek, który nic nie zmienia");
            }

            if (rowCount > 0)
            {
                entriesToReload.ForEach(e => e.Reload());
            }
            return rowCount;
        }
    }
}