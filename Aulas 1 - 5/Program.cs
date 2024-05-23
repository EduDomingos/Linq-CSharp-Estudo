
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

            List<List<int>> listaDeListas = FonteDados.ListaDeListas;
            #endregion

            #region Fundamentos
            // Query Syntax
            var resultado1 = from f in frutas where f.Contains('e') select f;

            // Method Syntax
            var resultado2 = frutas.Where(f => f.Contains('a'));

            Console.WriteLine(string.Join(" - ", resultado1));
            Console.WriteLine(string.Join(" - ", resultado2));
            #endregion

            #region Filtro Where
            var resultado3 = doisExponencial.Where(n => n < 200);
            var resultado4 = doisExponencial.Where(n => n < 100 || n > 500);
            var resultado5 = doisExponencial.Where(n => !doisExponencialProbido.Contains(n));
            var resultado6 = doisExponencial.Where(n => n > 2)
                                            .Where(n => n != 256)
                                            .Where(n => n < 1500);
            var resultado7 = pessoas.Where(p => p.Idade > 38);

            // Query Syntax
            var resultado8 = from p in pessoas where p.Idade < 38 select p;


            Console.WriteLine(string.Join(" - ", resultado3));
            Console.WriteLine(string.Join(" - ", resultado4));
            Console.WriteLine(string.Join(" - ", resultado5));
            Console.WriteLine(string.Join(" - ", resultado6));
            foreach (var pessoa in resultado7)
                Console.WriteLine($"{pessoa.Nome} tem {pessoa.Idade}");
            foreach (var pessoa in resultado8)
                Console.WriteLine($"{pessoa.Nome} tem {pessoa.Idade}");
            #endregion

            #region Projection Select
            var pessoasIdade = pessoas.Select(p => p.Idade);
            List<Pessoa> pessoasLista = pessoas.ToList();
            List<Pessoa> pessoasSemId = pessoas.Select(p => new Pessoa(0, p.Nome, p.Idade)).ToList();
            var pessoasSemIdAnonima = pessoas.Select(a => new
            {
                Nome = a.Nome,
                Idade = a.Idade
            }).ToList();

            IEnumerable<int> resultado9 = listaDeListas.SelectMany(lista => lista);

            foreach (var idade in pessoasIdade)
                Console.WriteLine(idade);

            foreach (var pessoa in pessoasLista)
                Console.WriteLine(pessoa.Nome);

            foreach (var pessoa in pessoasSemId)
                Console.WriteLine($"{pessoa.Id} - {pessoa.Nome}");

            foreach (var a in pessoasSemIdAnonima)
                Console.WriteLine($"{a.Nome} - {a.Idade}");

            foreach (var i in resultado9)
                Console.Write($"{i} ");
            Console.WriteLine();
            foreach (var i in resultado9.Distinct())
                Console.Write($"{i} ");
            Console.WriteLine();
            #endregion

            #region Conjunto (Distinct, Except)
            var listaDistinct = (from numero in resultado9 select numero).Distinct();
            foreach (var item in listaDistinct)
                Console.Write(item + " ");
            Console.WriteLine();

            var listaNomes = (from nome in nomes select nome).Distinct();
            foreach (var item in listaNomes)
                Console.Write(item + " ");
            Console.WriteLine();

            var listaNomesDistinct = (from nome in listaNomes select nome).Distinct(StringComparer.OrdinalIgnoreCase);
            foreach (var item in listaNomesDistinct)
                Console.Write(item + " ");
            Console.WriteLine();

            var listaIdadePessoasDistintas = pessoas.DistinctBy(p => p.Idade);
            foreach (var item in listaIdadePessoasDistintas)
                Console.WriteLine($"{item.Nome}, {item.Idade}");

            foreach (var item in doisExponencial.Except(doisExponencialProbido))
                Console.Write(item + " ");
            Console.WriteLine();

            foreach (var item in pessoas.ExceptBy(listaNomes, p => p.Nome, StringComparer.OrdinalIgnoreCase))
                Console.WriteLine($"{item.Nome}, {item.Idade}");
            #endregion

            #region Conjunto (Intersect, Union)
            foreach (var numero in doisExponencial.Intersect(doisExponencialProbido))
                Console.Write(numero + " ");
            Console.WriteLine();

            foreach (var nome in pessoas.Select(p=>p.Nome).Intersect(nomes))
                Console.Write(nome + " ");
            Console.WriteLine();

            foreach(var nomePessoa in pessoas.IntersectBy(nomes, p=>p.Nome))
                Console.Write(nomePessoa.Nome + " ");
            Console.WriteLine();

            foreach (var nome in pessoas2.Select(p=>p.Nome).Union(nomes))
                Console.Write(nome + " ");
            Console.WriteLine();

            foreach (var nome in pessoas2.Select(p=>p.Nome).Union(nomes, StringComparer.OrdinalIgnoreCase))
                Console.Write(nome + " ");
            Console.WriteLine();

            foreach (var nome in pessoas.UnionBy(pessoas2, n=>n.Nome, StringComparer.OrdinalIgnoreCase))
                Console.Write(nome.Nome + " ");
            Console.WriteLine();
            #endregion

            Console.WriteLine("");
        }
    }
}