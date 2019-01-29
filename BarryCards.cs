using System;
using static System.Console;
using System.Collections.Generic;
//using System.Linq;
namespace New_folder
{
	class Cards
    {
		public string front;
		public string back;
		
		public Cards(string front, string back)
		{
			this.front = front;
			this.back = back;
		}
		
		public static Cards AddCard()
		{
			string front;
			string back;
			Write("What is on the front?: ");
			front = ReadLine();
			Write("What is on the back?: ");
			back = ReadLine();
			Cards card = new Cards(front, back);
			return card;			
		}
		
		public static void DisplayCards(List<Cards> lst)
		{
			foreach (Cards i in lst)
			{
				Write("Front: {0,20}           ", i.front);
				WriteLine("Back: {0}", i.back);
			}
			WriteLine();
		}
		
		public static void Quiz(List<Cards> lst)
		{
			Write("How many questions?: ");
			int length = int.Parse(ReadLine());
			Random random = new Random();
			WriteLine();
			for(int i = 0; i < length; i++)
			{
				int index = random.Next(lst.Count);
				WriteLine("Definition: {0}", lst[index].back);
				string answer = lst[index].front;
				bool isCorrect = false; 
				while(!isCorrect)
				{
					WriteLine();
					WriteLine("What is the term?");
					Write("Answer: ");
					string userAnswer = ReadLine();
					if(userAnswer == answer)
					{
						WriteLine();
						WriteLine("Correct!");
						isCorrect = true;
					}
					else
					{
						WriteLine();
						WriteLine("Incorrect. Try Again!");
					}
				}
			}
		}
		//public override string ToString()
		//{
			//return "Front: " + front + "      Back: " + back;
		//}
	}
	
    class BarryCards
    {
        static void Main(string[] args)
        {
			WriteLine("Welcome to BarryCards!");
			WriteLine("If you would like to add a flashcard, please enter \"new\"");
			WriteLine("If you would like to display your current flashcards, please enter \"display\"");
			WriteLine("If you would like to end the program, please enter \"end\"");
			bool running = true;
			List<Cards> clctn = new List<Cards>();
			
			while(running)
			{
				WriteLine();
				Write("What would you like to do?: ");
				string input = ReadLine();
				WriteLine();
				bool propInput = false;

				while(!propInput)
				{
					if(input == "new")
					{
						clctn.Add(Cards.AddCard());
						WriteLine();
						propInput = true;
					}
					
					else if(input == "display")
					{
						Cards.DisplayCards(clctn);
						propInput = true;
					}
					
					else if(input == "end")
					{
						Write("Goodbye and Good Luck!");
						running = false;
						propInput = true;
					}
					
					else if(input == "quiz")
					{
						Cards.Quiz(clctn);
						propInput = true;
					}
					else
					{
						WriteLine("Improper input");
						WriteLine();
						Write("What would you like to do?: ");
						input = ReadLine(); 
					}
				}
			}
        }
    }
}
