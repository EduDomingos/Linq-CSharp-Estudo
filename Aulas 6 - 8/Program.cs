
namespace Linq_Estudo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("## Linq ## \n");

            #region Dados
            // "Banana", "Maça", "Pera", "Uva", "Laranja", "Melão", "Melancia", "Limão", "Abacate", "Caqui", "Cereja"
            IList<string> frutas = FonteDados.Frutas;

            // 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024
            IList<int> doisExponencial = FonteDados.DoisExponencial;

            // 1, 2, 4, 8, 512, 1024
            IList<int> doisExponencialProbido = FonteDados.DoisExponencialProibido;

            // "Eduardo", "Beatriz", "Nicolas", "Vilma", "EDUARDO", "nicolas", "Silva", "Santos", "Domingos", "domingos"
            IList<string> nomes = FonteDados.Nomes;

            IEnumerable<Pessoa> pessoas = FonteDados.Pessoas;

            IEnumerable<Pessoa> pessoas2 = FonteDados.GetPessoas();

            var pessoasFull = pessoas.Union(pessoas2).ToList();

            List<List<int>> listaDeListas = FonteDados.ListaDeListas;
            #endregion

            #region Ordenação (OrderBy, ThenBy, Reverse)
            foreach (var pessoa in pessoasFull.OrderBy(p => p.Nome))
                Console.Write(pessoa.Nome + " ");
            Console.WriteLine();

            foreach (var pessoa in pessoasFull.OrderBy(p => p.Nome).ThenBy(p => p.Idade))
                Console.WriteLine($"{pessoa.Nome}, {pessoa.Idade}");

            foreach (var pessoa in (from p in pessoasFull orderby p.Nome, p.Idade select p))
                Console.Write(pessoa.Nome + " ");
            Console.WriteLine();

            foreach (var numero in doisExponencial.Reverse())
                Console.Write(numero + " ");
            Console.WriteLine();


            foreach (var pessoa in pessoasFull.Where(p => p.Nome.Contains('d', StringComparison.OrdinalIgnoreCase)).OrderByDescending(p => p.Nome))
                Console.Write(pessoa.Nome + " ");
            Console.WriteLine();

            // Listas usam o método reverse() da Collections.Generics, é preciso passar para um Enumerable para usar o reverse() da Linq
            var listaNomesReverse = nomes.ToList().AsEnumerable().Reverse();
            #endregion

            #region Agregação (Aggregate (3 overloads), Average)
            Console.WriteLine(doisExponencial.Aggregate((n1,n2) => n1 + n2));

            Console.WriteLine(nomes.Aggregate((n1,n2) => n1 + ", " + n2));

            string listaNomesAlunos = nomes.Aggregate<string, string>("Alunos: ",(seed, nome)=>seed += nome + ", ");
            int indice = listaNomesAlunos.LastIndexOf(", ");
            Console.WriteLine(listaNomesAlunos.Remove(indice, 2));

            string listaNomesAlunos2 = nomes.Aggregate<string, string, string>("Alunos: ",
                                                        (seed, nomes) => seed += nomes + ", ",
                                                        resultado => resultado[..^2]);
            Console.WriteLine(listaNomesAlunos2);

            Console.WriteLine($"Média de idades: {pessoasFull.Average(p=>p.Idade):f2}");
            Console.WriteLine($"Média: {doisExponencial.Average(p=>p):f2}");
            #endregion

            #region Agregação (Count, LongCount, Sum, Max, Min)
            Console.WriteLine(nomes.Count());
            Console.WriteLine(doisExponencial.Count(n=>n>100));
            Console.WriteLine(nomes.Where(nome=>nome.Contains('a')).Count());

            Console.WriteLine(nomes.LongCount());
            Console.WriteLine(doisExponencial.LongCount(n=>n>100));

            Console.WriteLine(doisExponencial.Sum());
            Console.WriteLine(doisExponencial.Sum(n=>{
                if (n > 50)
                    return n;
                else
                    return 0;
            }));
            Console.WriteLine(doisExponencial.Where(n=> n>50).Sum());

            Console.WriteLine(pessoasFull.Max(p=>p.Idade));
            Console.WriteLine(pessoasFull.Where(p=>p.Id>50).DefaultIfEmpty(new Pessoa(51,"",51)).Max(p=>p.Idade));
            Console.WriteLine(doisExponencial.Max());


            Console.WriteLine(pessoasFull.Min(p=>p.Idade));
            Console.WriteLine(pessoasFull.Where(p=>p.Id<7).Min(p=>p.Idade));
            Console.WriteLine(doisExponencial.Min());

            #endregion
            Console.WriteLine("");
        }
    }
}