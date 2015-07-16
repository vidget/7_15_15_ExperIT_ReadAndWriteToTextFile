using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7_15_15_ExperIT_ReadAndWriteToTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates of LIST of PERSON called CLASSBODY
            List<Person> classbody = new List<Person>();

            string inputName;//string to hold the input stream

            StreamReader inputFile;
            //opens the TEMP.TXT file located in the projects BIN folder
            inputFile = File.OpenText("temp.txt");


            //does WHILE the file still has information 
            while (!inputFile.EndOfStream)
            {
                //an array of CHARS used to delimit the user input into 2 sepearte strings First and Last Name
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

                //creates an array called splitName and splits the inputFile ReadLine based on the deliminated Chars above
                string[] splitName = inputFile.ReadLine().Split(delimiterChars);

                //create a PERSON object called student
                Person student = new Person();

                // reads each element from the splitName array which hold the first and Last name

                //sets the the [0] value of the splitName array to the firstName of the student Object
                student.firstName = splitName[0];

                //sets the the [1] value of the splitName array to the lastName of the student Object
                student.lastName = splitName[1];

                //adds newly created STUDENT to the LIST called CLASSBODY
                classbody.Add(student);

            }
            inputFile.Close();//closes the opened file

            //Displays the contents of CLASSBODY LIST and Prompts the user for a name to ADD
            Console.WriteLine("These are the names currently stored in the FILE:\n");
            showStudents(classbody);//calls the method showStudents which prints out the list of students stored in CLASSBODY

            char done = 'Y';//for do-while loop condition
            do
            {
                int choice = 0;
                Console.WriteLine("\nChoose an action to perform");
                Console.WriteLine(" 1.) Add Name");
                Console.WriteLine(" 2.) Delete Name");
                Console.WriteLine(" 3.) View Current Group");
                Console.WriteLine(" 4.) Commit Group to File ");
                Console.WriteLine(" 5.) Exit and Write File ");
                Console.WriteLine(" 6.) Exit Only");

                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter a name to add to the FILE");
                        inputName = Console.ReadLine();
                        Person newPersonTemp = new Person();
                        newPersonTemp.firstName = inputName;
                        classbody.Add(newPersonTemp);
                        Console.Clear();
                        Console.WriteLine("These are the names you wish to WRITE to FILE:\n");
                        showStudents(classbody);

                        //Prompts the user if they want to add another person if 'N' for no is entered the do-while loop is exited otherwise another name is added to the CLASSBODY
                        Console.WriteLine("\nDo you want to perform another action (Y/N)?");
                        done = Console.ReadKey().KeyChar;

                    break;

                    case 2:
                    int userSelect = 0;
                    Console.Clear();
                    Console.WriteLine("Select a name to DELETE:\n");
                    for (int i = 0; i < classbody.Count; i++)
                    {
                        Console.Write(i+".)"+classbody[i].firstName.ToString()); //displays the firstName
                        Console.Write(" ");//adds a space between the first and last name when displaying
                        Console.Write(classbody[i].lastName.ToString());//displays the lastName
                        Console.Write("\n");//advances to the next line.

                    }
                    Console.Write("\nEnter the # to Delete >");
                        userSelect=int.Parse(Console.ReadLine());
                        classbody.RemoveAt(userSelect);//removes a name from the list CLASSBODY based on user input

                         Console.Clear();
                        Console.WriteLine("This is the NEW LIST of names");
                        showStudents(classbody);//reprint the list
                    break;

                    case 3:
                    Console.Clear();
                    Console.WriteLine("These are the names in current group:\n");
                    showStudents(classbody);
                    break;

                    case 4:
                         Console.Clear();//Clears the screen
                         writeFile(classbody);//Calls the writeFile Method

                    //try-catch to over-write the file "temp.txt" 
                  
                    break;

                    case 5:
                    writeFile(classbody);//Calls the writeFile Method
                    System.Environment.Exit(0);

                    break;

                    case 6:
                    
                    System.Environment.Exit(0);

                    break;
                    
                    default:
                    break;

                }

            } while (done == 'Y');

           

        }

        //This METHOD displays the LIST of first and last names in the CLASSBODY
        public static void showStudents(List<Person> classbody)
        {
            for (int i = 0; i < classbody.Count; i++)
            {
                Console.Write(classbody[i].firstName.ToString()); //displays the firstName
                Console.Write(" ");//adds a space between the first and last name when displaying
                Console.Write(classbody[i].lastName.ToString());//displays the lastName
                Console.Write("\n");//advances to the next line.

            }
        }


        public static void writeFile(List<Person> classbody)
        {

            //try-catch to over-write the file "temp.txt" 
            try
            {
                StreamWriter outputfile;
                outputfile = File.CreateText("temp.txt"); //creates a NEW file that writes over the old inputed file

                //based on the size of the CLASSBODY List elements are written to the file in this loop
                for (int x = 0; x < classbody.Count; x++)
                {
                    outputfile.Write(classbody[x].firstName.ToString()); //writes the first name
                    outputfile.Write(" ");//adds a space between the names
                    outputfile.Write(classbody[x].lastName.ToString());//writes the last name
                    outputfile.WriteLine();//next line
                }

                outputfile.Close();//closes the file
                Console.WriteLine("File Successfully Writen!\n\nPress Any Key to EXIT...");//tells the user the file was written
                Console.ReadKey();//waits for user to press any key before exiting the program


            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR writing the file: " + ex); //displays the error message when a file doesn't write successfully based on the error code thrown
                Console.ReadLine();//pause
            }

        }

    }
}
