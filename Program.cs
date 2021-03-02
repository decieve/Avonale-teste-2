using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Avonale_teste_2
{
    class Program
    {
        ///
        /// retorna quantos numeros sao maiores dentro da lista "LISTA" , o numero para a comparaçao e o NUMEROBASE
        /// 
        /// 
        public static int numerosmaiores(List<int> lista,double numeroBase)
        {
            if(lista.Count == 1)
            {
                return Convert.ToInt32(lista.First() > numeroBase);
            }
            else
            {
                return Convert.ToInt32(lista.First() > numeroBase) + numerosmaiores(lista.Skip(1).ToList(),numeroBase);
            }
        }
        /// <summary>
        ///  Retorna um número em formato double especificando a média da lista de inteiros
        /// </summary>
        /// <param name="lista" type="List<int>">
        ///    Lista de números para obter a média
        /// </param>
        /// <param name="size" type="int">
        ///    Tamanho da lista
        /// </param>
        /// <returns> double </returns>

        public static double recursivaMedia(List<int> lista,int size)
        {
            if(lista.Count == 1)
            {
                // Caso base == 1 , pois exceções serão lançadas caso a lista seja vazia
                // retorna cabeça da lista ( head , e também ultimo elemento ) 
                return (double)lista.First()/(double)size;
            }else 
            {
                // retorna a cabeça da lista (head) dividida pelo tamanho da lista (size) + a recursão da função com a cauda(tail) da funçao como paramentro 
                   return ((double)lista.First()/(double)size )+ recursivaMedia(lista.Skip(1).ToList(),size);
            }
        }
        // Inverte a lista 
        public static List<int> recursivaInvertida(List<int> lista)
        {
            if (lista.Count == 1)
            {
                List<int> listafinal = new List<int>();
                listafinal.Add(lista.First());
                return listafinal;
            }
            else
            {
                List<int> listafinal = new List<int>();
                listafinal.Add(lista.First());
                return recursivaInvertida(lista.Skip(1).ToList()).Concat(listafinal).ToList();
            }
        }
        public static void Main(string[] args)
        {
            List<int> list;
            int[] numeros = {1,2,3,3,6,5,7,9,10,0,15};
            list = new List<int>(numeros);
            try {
                double media = recursivaMedia(list, list.Count);
                 Console.WriteLine("média dos numeros :" + media);
                Console.WriteLine("números da lista maiores que a média:" + numerosmaiores(list, media));
            }catch(Exception e)
            {
                Console.WriteLine("Não foi possível calcular a média dos numeros, a lista está vazia!");
            }
            List<int> listaInvertida = recursivaInvertida(list);
            foreach (int i in listaInvertida)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadLine();
        }
    }
}
