using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Entidades
{
    public class Contratos
    {
        public String NumeroContrato { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public String Titular { get; set; }
        public String Poliza{ get; set; }
        public String PlanAsociado { get; set; }
        
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public Boolean Vigente { get; set; }
        public Boolean ConDeclaracionSalud { get; set; }//boolean estado checkbox
        public Double PrimaAnual { get; set; }
        public Double PrimaMensual { get; set; }
        public String Observaciones { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;

        public Contratos()
        {
            Entidades = new BeLifeEntities();

        }
        //METODOS CRUD
        public bool GrabarContrato()
        {
            try
            {
                Biblioteca.DALC.Contrato Con;
                Con = new DALC.Contrato();
                Biblioteca.Entidades.Planes Plan;
                Plan = new Planes();
                Biblioteca.Entidades.Tarificador Tar;
                Tar = new Tarificador();

                
                Con.Numero = this.NumeroContrato;
                Con.FechaCreacion = this.Creacion;
                Con.RutCliente = this.Titular;
                Con.CodigoPlan = this.PlanAsociado;
                //creo que debo recorrer los planes para saber que la poliza pertenece a cierto plan
                Plan.PolizaActual = this.Poliza;//Poliza
                Con.FechaInicioVigencia = this.InicioVigencia;
                Con.FechaFinVigencia = this.FinVigencia;
                Con.Vigente = this.Vigente;
                Con.DeclaracionSalud = this.ConDeclaracionSalud;
                //Con.PrimaAnual=Tar.calculoPrimasanual(Plan.PolizaActual,Con.RutCliente);
                Con.PrimaAnual = this.PrimaAnual;
                //Con.PrimaAnual=Tar.calculoPrimasmensual(Plan.PolizaActual,Con.RutCliente);
                Con.PrimaMensual = this.PrimaMensual;
                Con.Observaciones = this.Observaciones;

                Entidades.Contrato.Add(Con);
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }

        }

        public bool EliminarContrato()
        {
            try
            {

                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(NumeroContrato));
                Con.Vigente = this.Vigente;//Modificar el estado a no vigente
                Con.FechaTermino = this.Termino;
                //fecha fin al contrato *
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public bool ActualizarContrato()
        {
            try
            {
                Biblioteca.DALC.Contrato Con;

                Con = Entidades.Contrato.First(a => a.Numero.Equals(NumeroContrato));

                Biblioteca.Entidades.Planes Plan;
                Plan = new Planes();

                Con.Numero = this.NumeroContrato;
                Con.FechaCreacion = this.Creacion;
                //Con.FechaTermino = this.Termino;//no puede ser modificada
                Con.RutCliente = this.Titular;
                Con.CodigoPlan = this.PlanAsociado;
                Plan.BuscarPlan(Con.CodigoPlan);
                Plan.PolizaActual = this.Poliza;
                Con.FechaInicioVigencia = this.InicioVigencia;
                Con.FechaFinVigencia = this.FinVigencia;
                Con.Vigente = this.Vigente;
                Con.DeclaracionSalud = this.ConDeclaracionSalud;
                Con.PrimaAnual = this.PrimaAnual;
                Con.PrimaMensual = this.PrimaMensual;
                Con.Observaciones = this.Observaciones;


                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }

        }

        public bool BuscarContrato()
        {
            try
            {
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(NumeroContrato));
                this.NumeroContrato = Con.Numero;
                this.Creacion = Con.FechaCreacion;
                this.Termino = (DateTime)Con.FechaTermino;
                this.Titular = Con.RutCliente;
                this.PlanAsociado = Con.CodigoPlan;
                Plan.BuscarPlan(Con.CodigoPlan);//esto esta bien
                this.Poliza = Plan.PolizaActual;
                this.InicioVigencia = Con.FechaInicioVigencia;
                this.FinVigencia = Con.FechaFinVigencia;
                this.Vigente = Con.Vigente;
                this.ConDeclaracionSalud = Con.DeclaracionSalud;
                this.PrimaAnual = Con.PrimaAnual;
                this.PrimaMensual = Con.PrimaMensual;
                this.Observaciones = Con.Observaciones;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }


        }

        public List<Contratos> ListarTodo()
        {
            try
            {
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = Entidades.Contrato.ToList();

                Biblioteca.Entidades.Planes Plan;
                Plan = new Planes();

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Plan.BuscarPlan(Con.CodigoPlan); 
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }
        }
        public List<Contratos> ListarporNroContrato(String NumeroContrato)
        {
            try
            {
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = from c in Entidades.Contrato
                                     where c.Numero == NumeroContrato
                                     select c;

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }
        public List<Contratos> ListarporRut(String Rut)
        {
            try
            {
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = from r in Entidades.Contrato
                                     where r.RutCliente == Rut
                                     select r;

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }
        //FILTRAR POR NUMERO DE POLIZA ???
        public List<Contratos> ListarporNroPoliza(String Poliza)
        {
            try
            {
                //hay que corregir lo de poliza para que esto funcione
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = from c in Entidades.Contrato
                                     where c.Numero == NumeroContrato
                                     select c;

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }

        public bool BuscarContrato(String Codigo)
        {
            try
            {
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(Codigo));
                this.NumeroContrato = Con.Numero;
                this.Creacion = Con.FechaCreacion;
                this.Termino = (DateTime)Con.FechaTermino;
                this.Titular = Con.RutCliente;
                this.PlanAsociado = Con.CodigoPlan;
                Plan.BuscarPlan(Con.CodigoPlan);//esto esta bien
                this.Poliza = Plan.PolizaActual;
                this.InicioVigencia = Con.FechaInicioVigencia;
                this.FinVigencia = Con.FechaFinVigencia;
                this.Vigente = Con.Vigente;
                this.ConDeclaracionSalud = Con.DeclaracionSalud;
                this.PrimaAnual = Con.PrimaAnual;
                this.PrimaMensual = Con.PrimaMensual;
                this.Observaciones = Con.Observaciones;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }


        }


    }




}

