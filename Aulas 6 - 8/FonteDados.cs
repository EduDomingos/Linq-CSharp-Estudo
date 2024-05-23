
namespace Linq_Estudo
{
    public class FonteDados
    {
        public static IList<string> Frutas = ["Banana", "Maça", "Pera", "Uva", "Laranja", "Melão", "Melancia", "Limão", "Abacate", "Caqui", "Cereja"];
        public static IList<string> Nomes = ["Eduardo", "Beatriz", "Nicolas", "Vilma", "EDUARDO", "nicolas", "Silva", "Santos", "Domingos", "domingos"];
        public static IList<int> DoisExponencial = [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024];

        public static IList<int> DoisExponencialProibido = [1, 2, 4, 8, 512, 1024];

        public static IEnumerable<Pessoa> Pessoas = new List<Pessoa>()
        {
            new Pessoa(1, "Eduardo", 37),
            new Pessoa(2, "Beatriz", 29),
            new Pessoa(3, "Nicolas", 11),
            new Pessoa(4, "Vilma", 68),
            new Pessoa(5, "lívia", 68),
            new Pessoa(6, "eduardo", 11),
            new Pessoa(7, "beatriz", 39),
            new Pessoa(8, "nicolas", 37),
            new Pessoa(9, "vilma", 29),
            new Pessoa(10, "Lívia", 39)
        };

        public static List<List<int>> ListaDeListas = new List<List<int>>()
        {
            new List<int>(){1,2,3,4,5,},
            new List<int>(){6,7,8,9,},
            new List<int>(){4,5,6,7,8},
            new List<int>(){100,200,300,400,400,400,400}
        };

        public static IEnumerable<Pessoa> GetPessoas()
        {
            var pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa(11, "Eduardo", 25));
            pessoas.Add(new Pessoa(12, "Cindy", 33));
            pessoas.Add(new Pessoa(13, "Joana", 11));
            pessoas.Add(new Pessoa(14, "Amanda", 68));
            pessoas.Add(new Pessoa(15, "Brandon", 68));
            pessoas.Add(new Pessoa(16, "Merlin", 11));
            pessoas.Add(new Pessoa(17, "EDUARDO", 39));
            pessoas.Add(new Pessoa(18, "nicolas", 17));
            pessoas.Add(new Pessoa(19, "vilma", 19));
            pessoas.Add(new Pessoa(20, "Lívia", 9));

            return pessoas;
        }
    }
}