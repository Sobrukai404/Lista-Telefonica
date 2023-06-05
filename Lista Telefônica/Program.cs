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

        agenda.AdicionarContato("João", 123456789);
        agenda.AdicionarContato("Maria", 987654321);
        agenda.AdicionarContato("Ana", 456789123);

        // Exemplo de utilização das funcionalidades

        // Buscar contato por telefone
        Contato contatoTelefone = agenda.BuscarContatoPorTelefone(987654321);
        if (contatoTelefone != null)
        {
            Console.WriteLine("Contato encontrado por telefone: " + contatoTelefone.Nome);
        }
        else
        {
            Console.WriteLine("Nenhum contato encontrado por telefone.");
        }

        // Buscar contatos por nome
        List<Contato> contatosNome = agenda.BuscarContatoPorNome("João");
        if (contatosNome.Count > 0)
        {
            Console.WriteLine("Contatos encontrados por nome:");
            foreach (Contato contato in contatosNome)
            {
                Console.WriteLine(contato.Nome + " - " + contato.Telefone);
            }
        }
        else
        {
            Console.WriteLine("Nenhum contato encontrado por nome.");
        }

        // Excluir contato por telefone
        agenda.ExcluirContatoPorTelefone(123456789);

        // Ordenar contatos por nome
        List<Contato> contatosOrdenadosNome = agenda.OrdenarContatosPorNome();
        Console.WriteLine("Contatos ordenados por nome:");
        foreach (Contato contato in contatosOrdenadosNome)
        {
            Console.WriteLine(contato.Nome + " - " + contato.Telefone);
        }

        // Listar todos os contatos
        List<Contato> todosContatos = agenda.ListarTodosContatos();
        Console.WriteLine("Todos os contatos:");
        foreach (Contato contato in todosContatos)
        {
            Console.WriteLine(contato.Nome + " - " + contato.Telefone);
        }
    }
}
