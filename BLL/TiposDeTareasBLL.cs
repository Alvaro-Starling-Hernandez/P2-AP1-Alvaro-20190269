using P2_AP1_Alvaro_20190269.DAL;
using P2_AP1_Alvaro_20190269.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Alvaro_20190269.BLL
{
    public class TiposDeTareasBLL
    {

        public static TiposDeTareas Buscar(int id)
        {
            TiposDeTareas tiposDeTarea;
            Contexto contexto = new Contexto();

            try
            {
                tiposDeTarea = contexto.TiposDeTareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tiposDeTarea;
        }

        public static List<TiposDeTareas> GetList(Expression<Func<TiposDeTareas, bool>> criterio)
        {
            List<TiposDeTareas> lista = new List<TiposDeTareas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposDeTareas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<TiposDeTareas> GetTiposDeTareas()
        {
            List<TiposDeTareas> lista = new List<TiposDeTareas>();

            Contexto contexto = new Contexto();
            try
            {
                //lista = contexto.TiposDeTareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
