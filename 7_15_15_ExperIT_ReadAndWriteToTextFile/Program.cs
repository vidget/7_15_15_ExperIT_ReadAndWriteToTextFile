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
                //takes the user inputed name and adds it to a new PERSON called newPersonTemp then adds that PERSON to the CLASSBODY LIST
                Console.WriteLine("\nEnter a name to add to the FILE");
                inputName = Console.ReadLine();
                Person newPersonTemp = new Person();
                newPersonTemp.firstName = inputName;
                classbody.Add(newPersonTemp);

                //Clears the Screen then displays the list of names stored in the CLASSBODY 
                Console.Clear();
                Console.WriteLine("These are the names you wish to WRITE to FILE:\n");
                showStudents(classbody);

                //Prompts the user if they want to add another person if 'N' for no is entered the do-while loop is exited otherwise another name is added to the CLASSBODY
                Console.WriteLine("\nDo you want to add another person (Y/N)?");
                done = Console.ReadKey().KeyChar;
            } while (done == 'Y');

            Console.Clear();//Clears the screen

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

    }
}
