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

        public double calculoPrimas(double PrimaBase)
        {
            try
            {
                double Calculo = 0;
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.Entidades.Contratos Cont;
                Cont = new Entidades.Contratos();


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
