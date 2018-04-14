using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
using Biblioteca.Entidades;
namespace Biblioteca.Entidades
{
    public class Tarificador
    {
        //metodo tiene validaciones
        //metodo lleva parametros debe recibir la primaBase
        //validar x edad
        //validar por sexo
        //validar por Estado Civil

        //Este valor se devolvera al contrato

        public Tarificador()
        {
            Entidades = new BeLifeEntities();
        }

        public double calculoPrimas(String codigo)
        {
            try
            {

                double Calculo = 0;
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.Entidades.Contratos Cont;
                Cont = new Entidades.Contratos();
                double primab;
                if (Cont.BuscarContrato(codigo) == true)
                {
                    Biblioteca.Entidades.Clientes cli;
                    cli = new Clientes();
                    cli.Buscar(Cont.Titular);
                    Plan.BuscarPlan(Cont.PlanAsociado);
                    primab = Plan.PrimaBase;

                    int edad = (DateTime.Now.Year - cli.FechaNaci.Year);

                    if (edad >= 18 && edad <= 25) { }
                    else
                    {
                        if (edad >= 26 && edad <= 45)
                        {

                        }
                        else
                        {
                            if (edad>45)
                            {

                            }
                        }
                    }
                    
                }
                
                //le paso el valor de la prima base

                //valido

                //
                //Cont.PrimaAnual
                //Cont.PrimaMensual <-- quiero guardar valores



                return Calculo;
            }
            catch (Exception)
            {

                return 0;
            }
            

            

            
        }
    }
}
