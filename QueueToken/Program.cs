using System;
using System.Collections.Generic;

class ServiceToken
{
    private static int tokenCounter = 1;
    public int TokenID { get; private set; }
    public int Position { get; private set; }
    public DateTime TicketDateTime { get; private set; }
    public string Status { get; set; }

    public ServiceToken(int position)
    {
        TokenID = tokenCounter++;
        Position = position;
        TicketDateTime = DateTime.Now;
        Status = "Pending";
    }
}

class TicketManager
{
    public Queue<ServiceToken> TokenQueue { get; private set; } = new Queue<ServiceToken>();
    private List<ServiceToken> tokenHistory = new List<ServiceToken>();

    public void GenerateServiceToken()
    {
        ServiceToken token = new ServiceToken(TokenQueue.Count + 1);
        TokenQueue.Enqueue(token);
        tokenHistory.Add(token);
        Console.WriteLine($"Token Generated - ID: {token.TokenID}, Position: {token.Position}, Status: {token.Status}");
    }

    public ServiceToken GetNextToken()
    {
        if (TokenQueue.Count > 0)
        {
            return TokenQueue.Peek();
        }
        Console.WriteLine("No tokens available.");
        return null;
    }

    public void UpdateToken(int tokenID)
    {
        foreach (var token in tokenHistory)
        {
            if (token.TokenID == tokenID)
            {
                token.Status = "Completed";
                Console.WriteLine($"Token {tokenID} marked as Completed.");
                TokenQueue.Dequeue();
                return;
            }
        }
        Console.WriteLine("Token not found.");
    }

    public ServiceToken SkipToken()
    {
        if (TokenQueue.Count > 1)
        {
            TokenQueue.Dequeue();
            return GetNextToken();
        }
        Console.WriteLine("Not enough tokens to skip.");
        return null;
    }

    public void ListAllTokens()
    {
        Console.WriteLine("All Tokens:");
        foreach (var token in tokenHistory)
        {
            Console.WriteLine($"ID: {token.TokenID}, Position: {token.Position}, Time: {token.TicketDateTime}, Status: {token.Status}");
        }
    }
}

class Program
{
    static void Main()
    {
        TicketManager manager = new TicketManager();
        int choice;
        do
        {
            Console.WriteLine("\n* TOKEN MANAGEMENT SYSTEM\n");
            Console.WriteLine("1. Create Token");
            Console.WriteLine("2. Get Next Token");
            Console.WriteLine("3. Update Token");
            Console.WriteLine("4. Skip Token");
            Console.WriteLine("5. List all tokens");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your Choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice)) continue;

            switch (choice)
            {
                case 1:
                    manager.GenerateServiceToken();
                    break;
                case 2:
                    var nextToken = manager.GetNextToken();
                    if (nextToken != null)
                        Console.WriteLine($"Next Token ID: {nextToken.TokenID}, Position: {nextToken.Position}");
                    break;
                case 3:
                    Console.Write("Enter Token ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateID))
                        manager.UpdateToken(updateID);
                    break;
                case 4:
                    var skippedToken = manager.SkipToken();
                    if (skippedToken != null)
                        Console.WriteLine($"Skipped to Token ID: {skippedToken.TokenID}");
                    break;
                case 5:
                    manager.ListAllTokens();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        } while (choice != 6);
    }
}
