using ADO.NET_AddressBook;

ADO.NET_AddressBook.AddressBookRepo repo = new ADO.NET_AddressBook.AddressBookRepo();
Console.WriteLine("Enter your option to perform\n1. Create New Contact\n2. View the Contact Details\n3. Update the Details\n4. Delete the Details using name\n5. Add Multiple AddressBooks");
int input = Convert.ToInt32(Console.ReadLine());
switch (input)
{    
    case 1:
        ADO.NET_AddressBook.AddressBookModel bookModel = new ADO.NET_AddressBook.AddressBookModel();
        Console.WriteLine("Enter First Name");
        bookModel.FirstName = Console.ReadLine();
        Console.WriteLine("Enter Last Name");
        bookModel.LastName = Console.ReadLine();
        Console.WriteLine("Enter Address ");
        bookModel.Address = Console.ReadLine();
        Console.WriteLine("Enter City ");
        bookModel.City = Console.ReadLine();
        Console.WriteLine("Enter State ");
        bookModel.State = Console.ReadLine();
        Console.WriteLine("Enter Zip Code ");
        bookModel.ZipCode = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Phone ");
        bookModel.PhoneNumber = (int)Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Enter Email ");
        bookModel.Email = Console.ReadLine();
        repo.CreateNewContact(bookModel);                
        repo.RetrieveDataFromDatabase();
        break;
    case 2:
        repo.RetrieveDataFromDatabase();
        break;
    case 3:
        repo.RetrieveDataFromDatabase();
        repo.UpdateRecordDetails();
        repo.RetrieveDataFromDatabase();
        break;
    case 4:
        repo.RetrieveDataFromDatabase();
        repo.DeleteAddressBookContact();
        repo.RetrieveDataFromDatabase();
        break;
    case 5:
        List<AddressBookModel> list = new List<AddressBookModel>();
        Console.WriteLine("Enter number of contacts to Add");
        int number = Convert.ToInt32(Console.ReadLine());        
        int i = 0;
        while (i < number)
        {
            ADO.NET_AddressBook.AddressBookModel model = new ADO.NET_AddressBook.AddressBookModel();
            Console.WriteLine("Enter First Name");
            model.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            model.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address ");
            model.Address = Console.ReadLine();
            Console.WriteLine("Enter City ");
            model.City = Console.ReadLine();
            Console.WriteLine("Enter State ");
            model.State = Console.ReadLine();
            Console.WriteLine("Enter Zip Code ");
            model.ZipCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone ");
            model.PhoneNumber = (int)Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email ");
            model.Email = Console.ReadLine();
            list.Add(model);
            i++;
        }
        repo.AddMultipleEmployee(list);
        break;
    default:
        Console.WriteLine("Invalid Input");
        break;
}