using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };


            // 1. SELECT * of cars

            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi

            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

           
        }

        // . Number Examples

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            // Each Number multiplied by 3
            // take all numbers, but 9
            // Order number by ascending value


            var processedNumberList = numbers
                .Select(num => num * 3) // {3,6, 9,etc.}
                .Where(num => num != 9)// {all but the 9}
                .OrderBy(num => num);//{at the end, we order}


        }

        static public void SearchExamples()
        {

            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"

            };



            // 1 First of all elements

            var first= textList.First();


            // 2. First element that has "c"

            var cText = textList.First(text=> text.Equals("c"));

           // 3. First element that contains "j"
           var jText = textList.First(text=> text.Contains("j"));

           // 4. First element that constains Z or default
           var firstOrDefaultText = textList.FirstOrDefault(text=> text.Contains("z")); // "" or first element with  Z


            // 5. Last element that constains Z or default
            var LastOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); // "" or last element with  Z


            // 6. Single Values
            var uniqueTexts = textList.Single();
            var uniqueorDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };

            int[] otherEvenNumbers = { 0, 2, 6 };

            // Obtain {4, 8}

            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); // {4,8}

        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionsSelection = myOpinions.SelectMany(opinion => opinion.Split(","));


            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id= 1,
                    Name="Enterprise 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "nieto@gmail.com",
                            Salary =3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "aaa2@gmail.com",
                            Salary =1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "eaa@gmail.com",
                            Salary =2000
                        }

                    }
                },
                new Enterprise()
                {
                    Id= 2,
                    Name="Enterprise 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana@gmail.com",
                            Salary =3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@gmail.com",
                            Salary =1000
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "roberto",
                            Email = "roberto@gmail.com",
                            Salary =1500
                        }

                    }
                }

            };
            // obtain all employees of all enterprises

            var employeeList= enterprises.SelectMany(enterprise => enterprise.Employees);


            // Know if any list is empty

            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());


            // All enterpises at least has an employee with more than 1000$ of salary


            bool hasEmployeeWithSalaryMoreThanOrEqual1000 = enterprises.Any(enterprise => enterprise.Employees.Any(employee => employee.Salary >= 1000));


        }

        static public void linqCollections()
        {
            var firtList = new List <string> () { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };


            // INNER JOIN

            var commonResult = from element in firtList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            // INNER JOIN FORM 2

            var commonResult2 = firtList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new {element, secondElement}
                );


            // OUTER JOIN - LEFT

            var leftOuterJoin = from element in firtList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            //easy join

            var leftOuterJoin2 = from element in firtList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement};




            // OUTER JOIN - RIGHT

            var righttOuterJoin = from secondElement in secondList
                                  join element in firtList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };


            // UNION -- only left + right

            var unionList = leftOuterJoin.Union(righttOuterJoin);



        }


        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };


            // SKIP
            var skipTwoFirstValues = myList.Skip(2);// {3,4,5,6,7,8,9,10}

            var skipLastTwoValues = myList.SkipLast(2);// {1,2,3,4,5,6,7,8}

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); // {5,6,7,8,9,10}

            // TAKE

            var takeFirstTwoValues = myList.Take(2); // {1,2}

            var takeLastTwoValues = myList.TakeLast(2); //{9,10}

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // {1,2,3}
            

        }

        // PAGING with Skip y Take

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection,int pageNumber, int resultsPerPage)
        {
            int startIndex =(pageNumber - 1) * resultsPerPage; 
            return collection.Skip(startIndex).Take(resultsPerPage);

        }

        // VARIABLES
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());


            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Number: {0}  Square: {1}", number, Math.Pow(number, 2));
            }
        }

        // ZIP

        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word => numbers + "=" + word);
            // {"1=one", "2= two",...}
        }


        // REPEAT AND RANGE

        static public void repeatRangeLinq()
        {
            // Generate collection from 1- 1000 --> RANGE
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);


            // Repeat a value N times

            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}

        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certified = false,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = true,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
                
            };



            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified== false
                                       select student;

            var aprovedStudentsNames = from student in classRoom
                                  where student.Grade >= 50 && student.Certified == true
                                  select student.Name;



        }


        // ALL 

        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); //true


        }



        // Aggregate
        static public void aggregateQueries()
        {
            int [] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);


            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 4 => 7
            //etc

            string[] words = { "hello,","my", "name", "is", "Martin" }; // hello, my name is martin
            string greeting = words.Aggregate((prevGreeting, current ) => prevGreeting + current);

            // "" ,"hello,"
            //"hello,", "my" => hello,my
            // "hello, my ", "name" => hello, my name
            //etc.

        }

        //DISCTINCT

        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

           IEnumerable<int> distinctValues = numbers.Distinct();

        }

        // GroupBy

        static public void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // we will have two groups:
            // 1. The group that doesnt fit the condition ( odd numbers)
            // 2. the grou that fits the condition (even numbers)


            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 .... 2,4,6,8 (first the odds and then the even)
                }
            }

            // Another example

            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certified = false,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = true,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }

            };



            var certifiedQuery = classRoom.GroupBy(Student => Student.Certified && Student.Grade >= 50);

            // We obtain two groups
            // 1- Not certified students
            // 2- Certified students


            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("------{0} {1} -----", group.Key  );
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name); 
                }
            }

        }


        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first post",
                    Content = "My first content ",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=1,
                            Created = DateTime.Now,
                            Title ="My first comment",
                            Content ="My content"
                        },
                        new Comment()
                        {
                            Id=2,
                            Created = DateTime.Now,
                            Title ="My second comment",
                            Content ="My content"
                        }


                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second post",
                    Content = "My second content ",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=3,
                            Created = DateTime.Now,
                            Title ="My other comment",
                            Content ="My new content"
                        },
                        new Comment()
                        {
                            Id=4,
                            Created = DateTime.Now,
                            Title ="My other new comment",
                            Content ="My new content"
                        }


                    }
                }

            };

            var commentsContent = posts.SelectMany(Post => Post.Comments, (Post, comment) => new { PostId = Post.Id, CommentContent = comment.Content });














        }
















    }
}