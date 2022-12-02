

using System.Runtime.Serialization.Formatters.Binary;
using System;
using static System.Console;

Person person = new Person("Tom", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person, person2 };

// создаем объект SoapFormatter
BinaryFormatter binFormat =
new BinaryFormatter();

// получаем поток, куда будем записывать сериализованный объект
using (FileStream fs = new FileStream("people.bin", FileMode.OpenOrCreate))
            {
    binFormat.Serialize(fs, people);

                Console.WriteLine("Объект сериализован");

            }

            // десериализация
            using (FileStream fs = new FileStream("people.bin", FileMode.OpenOrCreate))
            {
                Person[] newPeople = (Person[])binFormat.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Person p in newPeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                }
            }
            Console.ReadLine();
        