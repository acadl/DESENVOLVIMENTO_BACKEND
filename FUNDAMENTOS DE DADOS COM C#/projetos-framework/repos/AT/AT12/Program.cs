namespace AT_12
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    namespace GerenciadorContatos
    {
        // Classe para representar um contato
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
        }

        // Classe base abstrata para formatadores de contato
        public abstract class ContatoFormatter
        {
            // Método virtual que deve ser sobrescrito pelas classes derivadas
            public abstract void ExibirContatos(List<Contato> contatos);

            // Método auxiliar para verificar se há contatos
            protected bool VerificarContatos(List<Contato> contatos)
            {
                if (contatos == null || contatos.Count == 0)
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                    return false;
                }
                return true;
            }
        }

        // Formatador para exibição em Markdown
        public class MarkdownFormatter : ContatoFormatter
        {
            public override void ExibirContatos(List<Contato> contatos)
            {
                if (!VerificarContatos(contatos)) return;

                Console.WriteLine("## Lista de Contatos\n");

                foreach (var contato in contatos)
                {
                    Console.WriteLine($"- **Nome:** {contato.Nome}");
                    Console.WriteLine($"- **Telefone:** {contato.Telefone}");
                    Console.WriteLine($"- **Email:** {contato.Email}");
                    Console.WriteLine(); // Linha em branco entre contatos
                }

                Console.WriteLine($"**Total de contatos:** {contatos.Count}");
            }
        }

        // Formatador para exibição em tabela
        public class TabelaFormatter : ContatoFormatter
        {
            public override void ExibirContatos(List<Contato> contatos)
            {
                if (!VerificarContatos(contatos)) return;

                // Calcula o tamanho das colunas baseado no conteúdo
                int maxNome = Math.Max(4, contatos.Max(c => c.Nome.Length));
                int maxTelefone = Math.Max(8, contatos.Max(c => c.Telefone.Length));
                int maxEmail = Math.Max(5, contatos.Max(c => c.Email.Length));

                int larguraTotal = maxNome + maxTelefone + maxEmail + 8; // +8 para separadores

                // Linha superior da tabela
                Console.WriteLine(new string('-', larguraTotal));

                // Cabeçalho
                Console.WriteLine($"| {"Nome".PadRight(maxNome)} | {"Telefone".PadRight(maxTelefone)} | {"Email".PadRight(maxEmail)} |");
                Console.WriteLine(new string('-', larguraTotal));

                // Dados dos contatos
                foreach (var contato in contatos)
                {
                    Console.WriteLine($"| {contato.Nome.PadRight(maxNome)} | {contato.Telefone.PadRight(maxTelefone)} | {contato.Email.PadRight(maxEmail)} |");
                }

                // Linha inferior da tabela
                Console.WriteLine(new string('-', larguraTotal));
                Console.WriteLine($"Total de contatos: {contatos.Count}");
            }
        }

        // Formatador para exibição em texto puro
        public class RawTextFormatter : ContatoFormatter
        {
            public override void ExibirContatos(List<Contato> contatos)
            {
                if (!VerificarContatos(contatos)) return;

                Console.WriteLine("=== Contatos Cadastrados ===\n");

                for (int i = 0; i < contatos.Count; i++)
                {
                    var contato = contatos[i];
                    Console.WriteLine($"{i + 1}. Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
                }

                Console.WriteLine($"\nTotal de contatos: {contatos.Count}");
            }
        }
        internal class Program
        {
            private static readonly string ARQUIVO_CONTATOS = "contatos.txt";

            static void Main(string[] args)
            {
                Console.WriteLine("Bem-vindo ao Gerenciador de Contatos Avançado!");
                Console.WriteLine("Agora com múltiplos formatos de exibição!\n");

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
                Console.WriteLine("=== Gerenciador de Contatos Avançado ===");
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
                            ListarContatosComFormato();
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
            /// Lista contatos permitindo escolher o formato de exibição
            /// </summary>
            static void ListarContatosComFormato()
            {
                try
                {
                    // Carrega os contatos do arquivo
                    List<Contato> contatos = CarregarContatos();

                    if (contatos.Count == 0)
                    {
                        Console.WriteLine("Nenhum contato cadastrado.");
                        return;
                    }

                    // Solicita o formato de exibição
                    ContatoFormatter formatter = EscolherFormatador();

                    if (formatter != null)
                    {
                        Console.WriteLine();
                        formatter.ExibirContatos(contatos);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao listar contatos: {ex.Message}");
                }
            }

            /// <summary>
            /// Permite ao usuário escolher o formatador desejado
            /// </summary>
            /// <returns>Instância do formatador escolhido</returns>
            static ContatoFormatter EscolherFormatador()
            {
                Console.WriteLine("=== Escolha o Formato de Exibição ===");
                Console.WriteLine("1 - Markdown (formato estruturado com emojis)");
                Console.WriteLine("2 - Tabela (formato de tabela organizada)");
                Console.WriteLine("3 - Texto Puro (formato simples e direto)");
                Console.Write("Escolha o formato (1-3): ");

                string escolha = Console.ReadLine();

                // Polimorfismo: retorna a instância apropriada baseada na escolha
                switch (escolha)
                {
                    case "1":
                        Console.WriteLine("Formato Markdown selecionado!");
                        return new MarkdownFormatter();
                    case "2":
                        Console.WriteLine("Formato Tabela selecionado!");
                        return new TabelaFormatter();
                    case "3":
                        Console.WriteLine("Formato Texto Puro selecionado!");
                        return new RawTextFormatter();
                    default:
                        Console.WriteLine("Opção inválida! Usando formato padrão (Texto Puro).");
                        return new RawTextFormatter();
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
                                Console.WriteLine($"Aviso: Erro ao processar linha {numeroLinha}: {ex.Message}");
                            }

                            numeroLinha++;
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    // Arquivo não existe ainda, retorna lista vazia
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
}
