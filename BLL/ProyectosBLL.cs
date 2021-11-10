using Microsoft.EntityFrameworkCore;
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
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }

        private static bool Insertar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var detalle in proyecto.Detalle)
                {
                    detalle.TiposDeTareas.TiempoAcomulado += detalle.Tiempo;
                    contexto.Entry(detalle.TiposDeTareas).State = EntityState.Modified;
                }

                contexto.Proyectos.Add(proyecto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyectoAnterior = contexto.Proyectos
                                               .Where(x => x.ProyectoId == proyecto.ProyectoId)
                                               .Include(x => x.Detalle)
                                               .ThenInclude(x => x.TiposDeTareas)
                                               .AsNoTracking()
                                               .SingleOrDefault();

                foreach(var detalle in proyectoAnterior.Detalle)
                {
                    var tarea = contexto.TiposDeTareas.Find(detalle.TiposDeTareas.TipoDeTareaId);
                    tarea.TiempoAcomulado -= detalle.Tiempo;
                    detalle.TiposDeTareas = tarea;
                    contexto.Entry(detalle.TiposDeTareas).State = EntityState.Modified;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle Where ProyectoId = {proyecto.ProyectoId}");

                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    var tarea = contexto.TiposDeTareas.Find(item.TiposDeTareas.TipoDeTareaId);
                    tarea.TiempoAcomulado += item.Tiempo;
                    item.TiposDeTareas = tarea;
                    contexto.Entry(item.TiposDeTareas).State = EntityState.Modified;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Existe(int id)
        {
            bool existe = false;
            Contexto contexto = new Contexto();

            try
            {
                existe = contexto.Proyectos.Any(x => x.ProyectoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return existe;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyecto = ProyectosBLL.Buscar(id);

                if (proyecto != null)
                {
                    foreach (var detalle in proyecto.Detalle)
                    {
                        detalle.TiposDeTareas.TiempoAcomulado -= detalle.Tiempo;
                        contexto.Entry(detalle.TiposDeTareas).State = EntityState.Modified;
                    }

                    contexto.Proyectos.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto;
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos.Where(x => x.ProyectoId == id)
                                             .Include(x => x.Detalle)
                                             .ThenInclude(x => x.TiposDeTareas)
                                             .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return proyecto;
        }

        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> Criterio)
        {
            List<Proyectos> lista = new();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(Criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return lista;
        }
    }
}
