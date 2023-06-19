using System;
using System.Collections.Generic;
using System.Linq;

class Contato
{
    private static int ultimoID = 0;

    public int ID { get; }
    public string Nome { get; set; }
    public int Telefone { get; set; }

    public Contato(string nome, int telefone)
    {
        ultimoID++;
        ID = ultimoID;
        Nome = nome;
        Telefone = telefone;
    }
}

class Agenda
{
    private List<Contato> contatos;

    public Agenda()
    {
        contatos = new List<Contato>();
    }

    public void AdicionarContato(string nome, int telefone)
    {
        Contato novoContato = new Contato(nome, telefone);
        contatos.Add(novoContato);
    }

    public Contato BuscarContatoPorTelefone(int telefone)
    {
        return contatos.Find(contato => contato.Telefone == telefone);
    }

    public List<Contato> BuscarContatoPorNome(string nome)
    {
        return contatos.FindAll(contato => contato.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public void ExcluirContatoPorTelefone(int telefone)
    {
        contatos.RemoveAll(contato => contato.Telefone == telefone);
    }

    public void ExcluirContatoPorNome(string nome)
    {
        contatos.RemoveAll(contato => contato.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public List<Contato> OrdenarContatosPorNome()
    {
        return contatos.OrderBy(contato => contato.Nome).ToList();
    }

    public List<Contato> OrdenarContatosPorTelefone()
    {
        return contatos.OrderBy(contato => contato.Telefone).ToList();
    }

    public List<Contato> ListarTodosContatos()
    {
        return contatos;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda();

        bool executar = true;
        while (executar)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Excluir contato por telefone");
            Console.WriteLine("3. Excluir contato por nome");
            Console.WriteLine("4. Ver contatos");
            Console.WriteLine("5. Procurar contato por nome");
            Console.WriteLine("6. Procurar contato por telefone");
            Console.WriteLine("7. Ordenar contatos por nome");
            Console.WriteLine("8. Ordenar contatos por telefone");
            Console.WriteLine("9. Sair");
            Console.WriteLine();

            Console.WriteLine("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1" or "Adicionar":
                    Console.WriteLine("Digite o nome do contato:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o telefone do contato:");
                    int telefone = Convert.ToInt32(Console.ReadLine());
                    agenda.AdicionarContato(nome, telefone);
                    Console.WriteLine("Contato adicionado com sucesso!");
                    break;
                case "2" or "Excluir por telefone":
                    Console.WriteLine("Digite o telefone do contato que deseja excluir:");
                    int telefoneExclusao = Convert.ToInt32(Console.ReadLine());
                    agenda.ExcluirContatoPorTelefone(telefoneExclusao);
                    Console.WriteLine("Contato excluído com sucesso!");
                    break;
                case "3" or "Excluir por nome":
                    Console.WriteLine("Digite o nome do contato que deseja excluir:");
                    string nomeExclusao = Console.ReadLine();
                    agenda.ExcluirContatoPorNome(nomeExclusao);
                    Console.WriteLine("Contato excluído com sucesso!");
                    break;
                case "4" or "Listar":
                    List<Contato> listaContatos = agenda.ListarTodosContatos();
                    Console.WriteLine("Lista Telefônica:");
                    foreach (Contato contato in listaContatos)
                    {
                        Console.WriteLine("ID: " + contato.ID);
                        Console.WriteLine("Nome: " + contato.Nome);
                        Console.WriteLine("Telefone: " + contato.Telefone);
                        Console.WriteLine("-------------------------------");
                    }
                    break;
                case "5" or "Procurar Contato":
                    Console.WriteLine("Digite o nome do contato que deseja procurar:");
                    string nomeProcura = Console.ReadLine();
                    List<Contato> contatosPorNome = agenda.BuscarContatoPorNome(nomeProcura);
                    Console.WriteLine("Contatos encontrados:");
                    foreach (Contato contato in contatosPorNome)
                    {
                        Console.WriteLine("Nome: " + contato.Nome + " - Telefone: " + contato.Telefone);
                    }
                    break;
                case "6" or "Procurar Telefone":
                    Console.WriteLine("Digite o telefone do contato que deseja procurar:");
                    int telefoneProcura = Convert.ToInt32(Console.ReadLine());
                    Contato contatoPorTelefone = agenda.BuscarContatoPorTelefone(telefoneProcura);
                    if (contatoPorTelefone != null)
                    {
                        Console.WriteLine("Contato encontrado:");
                        Console.WriteLine("ID: " + contatoPorTelefone.ID);
                        Console.WriteLine("Nome: " + contatoPorTelefone.Nome);
                        Console.WriteLine("Telefone: " + contatoPorTelefone.Telefone);
                    }
                    else
                    {
                        Console.WriteLine("Nenhum contato encontrado para o telefone informado.");
                    }
                    break;
                case "7" or "Ordenar Nome":
                    List<Contato> contatosOrdenadosPorNome = agenda.OrdenarContatosPorNome();
                    Console.WriteLine("Contatos ordenados por nome:");
                    foreach (Contato contato in contatosOrdenadosPorNome)
                    {
                        Console.WriteLine("ID: " + contato.ID);
                        Console.WriteLine("Nome: " + contato.Nome);
                        Console.WriteLine("Telefone: " + contato.Telefone);
                        Console.WriteLine("-------------------------------");
                    }
                    break;
                case "8" or "Ordenar Telefone":
                    List<Contato> contatosOrdenadosPorTelefone = agenda.OrdenarContatosPorTelefone();
                    Console.WriteLine("Contatos ordenados por telefone:");
                    foreach (Contato contato in contatosOrdenadosPorTelefone)
                    {
                        Console.WriteLine("ID: " + contato.ID);
                        Console.WriteLine("Nome: " + contato.Nome);
                        Console.WriteLine("Telefone: " + contato.Telefone);
                        Console.WriteLine("-------------------------------");
                    }
                    break;
                case "9":
                    executar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("Operação concluída com sucesso!");
            Console.WriteLine();
        }
    }
}