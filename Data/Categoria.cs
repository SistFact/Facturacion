using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
  public class Categoria 
    {

        public Categoria() 
        { }

        public void InsertCat(string Descripcion)
        {
            try
            {
                using (var context = new Data.FacturacionEntities())
                {
                    context.InsercionCat(Descripcion);
                    context.SaveChanges();
                }
            }
            catch (Exception e) 
            {
                System.Console.WriteLine(e.Message);
            }

        }
    }
}
