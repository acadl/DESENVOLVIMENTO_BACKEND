namespace AT_11
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }

        // Converte o contato para o formato do arquivo (CSV)
        public string ToFileFormat()
        {
            return $"{Nome},{Telefone},{Email}";
        }

        // Cria um contato a partir de uma linha do arquivo
        public static Contato FromFileFormat(string linha)
        {
            string[] dados = linha.Split(',');
            if (dados.Length == 3)
            {
                return new Contato(dados[0], dados[1], dados[2]);
            }
            throw new FormatException("Formato de linha inválido no arquivo.");
        }

        // Override do ToString para exibição formatada
        public override string ToString()
        {
            return $"Nome: {Nome} | Telefone: {Telefone} | Email: {Email}";
        }
    }
    internal class Program
    {
        private static readonly string ARQUIVO_CONTATOS = "contatos.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Gerenciador de Contatos!");
            Console.WriteLine();

            bool continuar = true;
            while (continuar)
            {
                continuar = ExibirMenuPrincipal();
            }

            Console.WriteLine("Encerrando programa...");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Exibe o menu principal e processa a escolha do usuário
        /// </summary>
        /// <returns>True se deve continuar, False se deve sair</returns>
        static bool ExibirMenuPrincipal()
        {
            Console.WriteLine("=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            try
            {
                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarContato();
                        break;
                    case "2":
                        ListarContatos();
                        break;
                    case "3":
                        return false; // Sair do programa
                    default:
                        Console.WriteLine("Opção inválida! Por favor, escolha uma opção de 1 a 3.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            Console.WriteLine();
            return true; // Continuar no programa
        }

        /// <summary>
        /// Adiciona um novo contato solicitando dados do usuário
        /// </summary>
        static void AdicionarContato()
        {
            try
            {
                Console.WriteLine("=== Adicionar Novo Contato ===");

                // Solicita dados do contato
                Console.Write("Nome: ");
                string nome = Console.ReadLine()?.Trim();

                Console.Write("Telefone: ");
                string telefone = Console.ReadLine()?.Trim();

                Console.Write("Email: ");
                string email = Console.ReadLine()?.Trim();

                // Validação básica dos dados
                if (string.IsNullOrWhiteSpace(nome) ||
                    string.IsNullOrWhiteSpace(telefone) ||
                    string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Erro: Todos os campos devem ser preenchidos!");
                    return;
                }

                // Validação básica do email
                if (!email.Contains("@") || !email.Contains("."))
                {
                    Console.WriteLine("Erro: Email deve conter '@' e '.'!");
                    return;
                }

                // Cria o contato e salva no arquivo
                Contato novoContato = new Contato(nome, telefone, email);
                SalvarContato(novoContato);

                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar contato: {ex.Message}");
            }
        }

        /// <summary>
        /// Salva um contato no arquivo
        /// </summary>
        /// <param name="contato">Contato a ser salvo</param>
        static void SalvarContato(Contato contato)
        {
            try
            {
                // Usa StreamWriter com append=true para adicionar ao final do arquivo
                using (StreamWriter writer = new StreamWriter(ARQUIVO_CONTATOS, append: true))
                {
                    writer.WriteLine(contato.ToFileFormat());
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Erro: Diretório não encontrado para salvar o arquivo.");
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Erro: Sem permissão para escrever no arquivo.");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erro de E/S ao salvar contato: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Lista todos os contatos salvos no arquivo
        /// </summary>
        static void ListarContatos()
        {
            try
            {
                // Verifica se o arquivo existe
                if (!File.Exists(ARQUIVO_CONTATOS))
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                    return;
                }

                // Lê todos os contatos do arquivo
                List<Contato> contatos = CarregarContatos();

                if (contatos.Count == 0)
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                    return;
                }

                // Exibe os contatos
                Console.WriteLine("=== Contatos Cadastrados ===");
                for (int i = 0; i < contatos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contatos[i]}");
                }
                Console.WriteLine($"\nTotal de contatos: {contatos.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar contatos: {ex.Message}");
            }
        }

        /// <summary>
        /// Carrega todos os contatos do arquivo
        /// </summary>
        /// <returns>Lista de contatos</returns>
        static List<Contato> CarregarContatos()
        {
            List<Contato> contatos = new List<Contato>();

            try
            {
                if (!File.Exists(ARQUIVO_CONTATOS))
                {
                    return contatos; // Retorna lista vazia
                }

                // Usa StreamReader para ler o arquivo
                using (StreamReader reader = new StreamReader(ARQUIVO_CONTATOS))
                {
                    string linha;
                    int numeroLinha = 1;

                    while ((linha = reader.ReadLine()) != null)
                    {
                        try
                        {
                            // Ignora linhas vazias
                            if (string.IsNullOrWhiteSpace(linha))
                            {
                                numeroLinha++;
                                continue;
                            }

                            Contato contato = Contato.FromFileFormat(linha);
                            contatos.Add(contato);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Aviso: Linha {numeroLinha} do arquivo possui formato inválido e foi ignorada.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"⚠Aviso: Erro ao processar linha {numeroLinha}: {ex.Message}");
                        }

                        numeroLinha++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo de contatos não encontrado. Será criado ao adicionar o primeiro contato.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Erro: Sem permissão para ler o arquivo de contatos.");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erro de E/S ao carregar contatos: {ex.Message}");
                throw;
            }

            return contatos;
        }
    }
}
