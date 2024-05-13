using System;
using System.Collections.Generic;

class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
}

class FootballManager
{
    private List<Player> players = new List<Player>();
    private int nextId = 1;

    public void CreatePlayer()
    {
        Player newPlayer = new Player();
        Console.WriteLine("Digite o nome do jogador:");
        newPlayer.Name = Console.ReadLine();
        Console.WriteLine("Digite a idade do jogador:");
        newPlayer.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a posição do jogador:");
        newPlayer.Position = Console.ReadLine();

        newPlayer.Id = nextId++;
        players.Add(newPlayer);

        Console.WriteLine("Jogador adicionado com sucesso!");
    }

    public void ReadPlayers()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Nenhum jogador cadastrado.");
        }
        else
        {
            Console.WriteLine("Lista de jogadores:");
            foreach (Player player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Nome: {player.Name}, Idade: {player.Age}, Posição: {player.Position}");
            }
        }
    }

    public void UpdatePlayer()
    {
        Console.WriteLine("Digite o ID do jogador que deseja atualizar:");
        int id = Convert.ToInt32(Console.ReadLine());

        Player playerToUpdate = players.Find(p => p.Id == id);

        if (playerToUpdate != null)
        {
            Console.WriteLine("Digite o novo nome do jogador:");
            playerToUpdate.Name = Console.ReadLine();
            Console.WriteLine("Digite a nova idade do jogador:");
            playerToUpdate.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a nova posição do jogador:");
            playerToUpdate.Position = Console.ReadLine();

            Console.WriteLine("Jogador atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Jogador não encontrado.");
        }
    }

    public void DeletePlayer()
    {
        Console.WriteLine("Digite o ID do jogador que deseja excluir:");
        int id = Convert.ToInt32(Console.ReadLine());

        Player playerToDelete = players.Find(p => p.Id == id);

        if (playerToDelete != null)
        {
            players.Remove(playerToDelete);
            Console.WriteLine("Jogador excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Jogador não encontrado.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FootballManager manager = new FootballManager();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar jogador");
            Console.WriteLine("2. Listar jogadores");
            Console.WriteLine("3. Atualizar jogador");
            Console.WriteLine("4. Excluir jogador");
            Console.WriteLine("5. Sair");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.CreatePlayer();
                    break;
                case 2:
                    manager.ReadPlayers();
                    break;
                case 3:
                    manager.UpdatePlayer();
                    break;
                case 4:
                    manager.DeletePlayer();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
