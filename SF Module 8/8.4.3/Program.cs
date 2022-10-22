using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

internal class Program
{
    private static void Main(string[] args)
    {
        var person = new Contact("BLEAT", 841416341684684, "MEDVED@mail.ru");

        BinaryFormatter binaryFormatter = new BinaryFormatter();


        using(var fs = new FileStream("bufferSize.dat", FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fs, person);
            Console.WriteLine("Объект сериализован");
        }





    }
}

[Serializable]
class Contact
{
    public string Name { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, long phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}